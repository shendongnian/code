    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Win32;
    namespace MSKeyFinder
    {
        public class KeyDecoder
        {
            public enum Key { XP, Office10, Office11 };
            public static byte[] GetRegistryDigitalProductId(Key key)
            {
                byte[] digitalProductId = null;
                RegistryKey registry = null;
                switch (key)
                {
                    // Open the XP subkey readonly.
                    case Key.XP:
                        registry =
                          Registry.LocalMachine.
                            OpenSubKey(
                              @"SOFTWARE\Microsoft\Windows NT\CurrentVersion",
                                false);
                        break;
                    // Open the Office 10 subkey readonly.
                    case Key.Office10:
                        registry =
                          Registry.LocalMachine.
                            OpenSubKey(
                              @"SOFTWARE\Microsoft\Office\10.0\Registration\" + 
                              @"{90280409-6000-11D3-8CFE-0050048383C9}",
                              false);
                        // TODO: Open the registry key.
                        break;
                    // Open the Office 11 subkey readonly.
                    case Key.Office11:
                        // TODO: Open the registry key.
                        break;
                }
                if (registry != null)
                {
                    // TODO: For other products, key name maybe different.
                    digitalProductId = registry.GetValue("DigitalProductId")
                      as byte[];
                    registry.Close();
                }
                return digitalProductId;
            }
            public static string DecodeProductKey(byte[] digitalProductId)
            {
                // Offset of first byte of encoded product key in 
                //  'DigitalProductIdxxx" REG_BINARY value. Offset = 34H.
                const int keyStartIndex = 52;
                // Offset of last byte of encoded product key in 
                //  'DigitalProductIdxxx" REG_BINARY value. Offset = 43H.
                const int keyEndIndex = keyStartIndex + 15;
                // Possible alpha-numeric characters in product key.
                char[] digits = new char[]
          {
            'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'M', 'P', 'Q', 'R', 
            'T', 'V', 'W', 'X', 'Y', '2', '3', '4', '6', '7', '8', '9',
          };
                // Length of decoded product key
                const int decodeLength = 29;
                // Length of decoded product key in byte-form.
                // Each byte represents 2 chars.
                const int decodeStringLength = 15;
                // Array of containing the decoded product key.
                char[] decodedChars = new char[decodeLength];
                // Extract byte 52 to 67 inclusive.
                ArrayList hexPid = new ArrayList();
                for (int i = keyStartIndex; i <= keyEndIndex; i++)
                {
                    hexPid.Add(digitalProductId[i]);
                }
                for (int i = decodeLength - 1; i >= 0; i--)
                {
                    // Every sixth char is a separator.
                    if ((i + 1) % 6 == 0)
                    {
                        decodedChars[i] = '-';
                    }
                    else
                    {
                        // Do the actual decoding.
                        int digitMapIndex = 0;
                        for (int j = decodeStringLength - 1; j >= 0; j--)
                        {
                            int byteValue = (digitMapIndex << 8) | (byte)hexPid[j];
                            hexPid[j] = (byte)(byteValue / 24);
                            digitMapIndex = byteValue % 24;
                            decodedChars[i] = digits[digitMapIndex];
                        }
                    }
                }
                return new string(decodedChars);
            }
        }
    }
