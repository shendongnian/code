       public static partial class MString
       {
          ...
    
          /// <summary>
          /// Method to perform a very simple (and classical) encryption for a string. This is NOT at 
          /// all secure, it is only intended to make the string value non-obvious at a first glance.
          ///
          /// The shiftOrUnshift argument is an arbitrary "key value", and must be a non-zero integer 
          /// between -65535 and 65535 (inclusive). To decrypt the encrypted string you use the negative 
          /// value. For example, if you encrypt with -42, then you decrypt with +42, or vice-versa.
          ///
          /// This is inspired by, and largely based on, this:
          /// https://stackoverflow.com/a/13026595/253938
          /// </summary>
          /// <param name="inputString">string to be encrypted or decrypted, must not be null</param>
          /// <param name="shiftOrUnshift">see above</param>
          /// <returns>encrypted or decrypted string</returns>
          public static string CaesarCipher(string inputString, int shiftOrUnshift)
          {
             // Check C# is still C#
             Debug.Assert(char.MinValue == 0 && char.MaxValue == UInt16.MaxValue);
    
             const int C64K = UInt16.MaxValue + 1;
    
             // Check the arguments
             if (inputString == null)
                throw new ArgumentException("Must not be null.", "inputString");
             if (shiftOrUnshift == 0)
                throw new ArgumentException("Must not be zero.", "shiftOrUnshift");
             if (shiftOrUnshift <= -C64K || shiftOrUnshift >= C64K)
                throw new ArgumentException("Out of range.", "shiftOrUnshift");
    
             // Perform the Caesar cipher shifting, using modulo operator to provide wrap-around
             char[] charArray = new char[inputString.Length];
             for (int i = 0; i < inputString.Length; i++)
             {
                charArray[i] = 
                      Convert.ToChar((Convert.ToInt32(inputString[i]) + shiftOrUnshift) % C64K);
             }
    
             // Return the result as a new string
             return new string(charArray);
          }
    
          ...
       }
