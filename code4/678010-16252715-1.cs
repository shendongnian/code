        static private dynamic[] testSet = new dynamic[] { 5L, 4D, 3F, null, 2U, 1M, null, 0UL };
        static void Main(string[] args)
        {
            Stopwatch st1 = new Stopwatch();
            st1.Start();
            for(int i = 0; i < 100000; i++)
                Test1();
            st1.Stop();
            Stopwatch st2 = new Stopwatch();
            st2.Start();
            for(int i = 0; i < 100000; i++)
                Test2();
            st2.Stop();
        }
        static public void Test1()
        {
            var result = testSet.OrderBy(x => x == null ? (decimal?)null : (decimal)x).ToArray();
        }
        static public void Test2()
        {
            var result = testSet.OrderBy(x => (object)x, new HeterogeneousNumbersComparer()).ToArray();
        }
        
        public class HeterogeneousNumbersComparer : IComparer<object>
        {
            public int Compare(object a, object b)
            {
                if (a == null)
                    if (b == null)
                        return 0;
                    else
                        return -1;
                else if (b == null)
                    return +1;
                if (a.GetType() == b.GetType())
                {
                    switch(Type.GetTypeCode(a.GetType()))
                    {
                        case TypeCode.Byte:
                            return ((Byte)a).CompareTo((Byte)b);
                        case TypeCode.Decimal:
                            return ((Decimal)a).CompareTo((Decimal)b);
                        case TypeCode.Double:
                            return ((Double)a).CompareTo((Double)b);
                        case TypeCode.Int16:
                            return ((Int16)a).CompareTo((Int16)b);
                        case TypeCode.Int32:
                            return ((Int32)a).CompareTo((Int32)b);
                        case TypeCode.Int64:
                            return ((Int64)a).CompareTo((Int64)b);
                        case TypeCode.SByte:
                            return ((SByte)a).CompareTo((SByte)b);
                        case TypeCode.Single:
                            return ((Single)a).CompareTo((Single)b);
                        case TypeCode.UInt16:
                            return ((UInt16)a).CompareTo((UInt16)b);
                        case TypeCode.UInt32:
                            return ((UInt32)a).CompareTo((UInt32)b);
                        case TypeCode.UInt64:
                            return ((UInt64)a).CompareTo((UInt64)b);
                    }
                }
                return Convert.ToDecimal(a).CompareTo(Convert.ToDecimal(b));
            }
        }
    }
