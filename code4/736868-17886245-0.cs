    using System;
    
    namespace BitBangingDate
    {
        class Program
        {
            static void Main(string[] args)
            {
                CompactDateManipulator x = new CompactDateManipulator();
                Console.WriteLine(x.ToString());
                x.Month = 7;
                x.Day = 27;
                x.Seconds = 1234;
                Console.WriteLine(x.ToString());
            }
        }
    
        class CompactDateManipulator
        {
            CompactDate _date = new CompactDate();
    
            public int Month
            {
                get
                {
                    return BoolArrayToInt(_date.month);
                }
                set
                {
                    IntToBoolArray(ref _date.month, value);
                }
            }
            public int Day
            {
                get
                {
                    return BoolArrayToInt(_date.day);
                }
                set
                {
                    IntToBoolArray(ref _date.day, value);
                }
            }
            public int Seconds
            {
                get
                {
                    return BoolArrayToInt(_date.second);
                }
                set
                {
                    IntToBoolArray(ref _date.second, value);
                }
            }
    
            //utility methods
            void IntToBoolArray(ref bool[] bits, int input)
            {
                var len = bits.Length;
                for (int i = 0; i < len; i++)
                {
                    bits[i] = (input & 1) == 1 ? true : false;
                    input >>= 1;
                }
            }
            int BoolArrayToInt(bool[] bits)
            {
                if (bits.Length > 32) throw new ArgumentException("Can only fit 32 bits in a int");
                int r = 0;
                for (int i = 0; i < bits.Length; i++)
                {
                    if (bits[i]) r |= 1 << i;
                }
                return r;
            }
            public override string ToString()
            {
                return String.Format("Stored Date mm/dd/ss: {0}/{1}/{2}", Month, Day, Seconds);
            }
        }
    
        class CompactDate
        {
            //Layout  Month(5)    Day(9)       Hour(5)  Seconds (12)
            //        11111       111111111    11111    111111111111 
            public bool[] month = new bool[5];
            public bool[] day = new bool[9];
            public bool[] hour = new bool[5];
            public bool[] second = new bool[12];
        }
    }
