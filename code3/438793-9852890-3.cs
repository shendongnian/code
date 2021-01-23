        public void Main()
        {
            // Some test values.
            ushort address16 = ushort.MaxValue;
            uint address32 = uint.MaxValue;
            // Upper:
            ulong valueUpper = address16;           // Value contains 0x000000000000FFFF
            valueUpper = valueUpper << 48;          // Value contains 0xFFFF000000000000
            valueUpper += (uint)Mask.Upper;         // Value contains 0xFFFF000000000001
            // Lower:
            ulong valueLower = address16;           // Value contains 0x000000000000FFFF
            valueLower = valueLower << 32;          // Value contains 0x0000FFFF00000000
            // No need to set a 0-bit, it is already 0
            // DWord:
            ulong valueDword = address32;           // Value contains 0x00000000FFFFFFFF
            valueDword = valueDword << 32;          // Value contains 0xFFFFFFFF00000000
            valueDword += (uint)Mask.DoubleWord;    // Value contains 0xFFFFFFFF00000010
            ulong addr1 = ParseAddress((long)valueUpper);
            ulong addr2 = ParseAddress((long)valueLower);
            ulong addr3 = ParseAddress((long)valueDword);
        }
        public ulong ParseAddress(long address)
        {
            // Casting to ulong, as negative values don't make sense in addresses or bitwise operations.
            ulong value = (ulong)address;
            // Take the mask from the least significant bits
            Mask mask = (Mask)(value & uint.MaxValue);
            
            // Shift the mask bytes "off" the addr, get the remaining address. 
            ulong addr = ((ulong)value >> 32);
            // Is the doubleword bit set?
            if ((mask & Mask.DoubleWord) == Mask.DoubleWord)
            {
                return addr;
            }
            else if ((mask & Mask.Upper) == Mask.Upper)
            {
                return (addr >> 16);
            }
            else
            {
                return addr;
            }
        }
        [Flags]
        public enum Mask : uint
        {
            Upper = 1,
            DoubleWord = 2,
        }
