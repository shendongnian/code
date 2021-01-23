        var result = new dynamic[] { 5L, 4D, 3F, 2U, 1M, null, 0UL }.OrderBy(x => (object)x, new HeterogeneousNumbersComparer()).ToArray();
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
                        // Implement the other types like UInt16, Single, etc.
                    }
                }
                return Convert.ToDecimal(a).CompareTo(Convert.ToDecimal(b));
            }
        }
