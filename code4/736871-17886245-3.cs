    using System;
    using System.Collections;
    
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
                x.Minute = 1234;
                Console.WriteLine(x.ToString());
    
                var bitArr = x.GetCompactedArray();
    
                CompactDateManipulator x1 = new CompactDateManipulator();//create new blank date to test whether can be reiitialised from BitArray
    
                x1.ReinitialiseDateFromBitArray(bitArr);
                
                Console.WriteLine(x1.ToString());
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
            public int Minute
            {
                get
                {
                    return BoolArrayToInt(_date.minute);
                }
                set
                {
                    IntToBoolArray(ref _date.minute, value);
                }
            }
    
            public BitArray GetCompactedArray()
            {
                return _date.GetFullArray();
            }
    
            public void ReinitialiseDateFromBitArray(BitArray arr)
            {
                _date.SetDate(arr);
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
                return String.Format("Stored Date mm/dd/ss: {0}/{1}/{2}", Month, Day, Minute);
            }
        }
    
        class CompactDate
        {
            //Layout  Month(5)    Day(9)     Minute (12)
            //        11111       111111111  111111111111 
            public bool[] month = new bool[5];
            public bool[] day = new bool[9];
            public bool[] minute = new bool[12];
            public BitArray GetFullArray()
            {
                int fullLen = month.Length + day.Length + minute.Length;
                BitArray full = new BitArray(fullLen);
                int index = 0;
                for (int i = 0; i < month.Length; i++,index++)
                {
                    full.Set(index,month[i]);
                }
                for (int i = 0; i < day.Length; i++, index++)
                {
                    full.Set(index, day[i]);
                }
                for (int i = 0; i < minute.Length; i++, index++)
                {
                    full.Set(index, minute[i]);
                }
                return full;
            }
            public void SetDate(BitArray arr)
            {
                int index = 0;
                for (int i = 0; i < month.Length; i++, index++)
                {
                    month[i] = arr.Get(index);
                }
                for (int i = 0; i < day.Length; i++, index++)
                {
                    day[i] = arr.Get(index);
                }
                for (int i = 0; i < minute.Length; i++, index++)
                {
                    minute[i] = arr.Get(index);
                }
            }
        }
    }
