     public static bool BetweenNumeric<T1, T2, T3>(this T1 actual, T2 lowest, T3 highest)
                where T1 : IConvertible
                where T2 : IConvertible
                where T3 : IConvertible
            {
                try
                {
                    var actualDouble = Convert.ToDouble(actual);
                    var lowestDouble = Convert.ToDouble(lowest);
                    var highestDouble = Convert.ToDouble(highest);
                    return (actualDouble).CompareTo(lowestDouble) >= 0 && actualDouble.CompareTo(highestDouble) <= 0;
                }
                catch
                {
                    return false;
                }
            }
