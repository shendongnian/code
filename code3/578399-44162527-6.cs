    public static class HelperFunctions
    {
        public static bool AreSpansOverlapping(Tuple<DateTime,DateTime> span1, Tuple<DateTime,DateTime> span2)
        {
            if (span1 == null || span2 == null)
            {
                return false;
            }
            else if ((new DateTime[] { span1.Item1, span1.Item2, span2.Item1, span2.Item2 }).Any(v => v == DateTime.MinValue))
            {
                return false;
            }
            else
            {
                if (span1.Item1 > span1.Item2)
                {
                    span1 = new Tuple<DateTime, DateTime>(span1.Item2, span1.Item1);
                }
                if (span2.Item1 > span2.Item2)
                {
                    span2 = new Tuple<DateTime, DateTime>(span2.Item2, span2.Item1);
                }
    
                return 
                ((
                    (span1.Item1 <= span2.Item1 && span1.Item2 >= span2.Item1) 
                    || (span1.Item1 <= span2.Item2 && span1.Item2 >= span2.Item2)
                ) || (
                    (span2.Item1 <= span1.Item1 && span2.Item2 >= span1.Item1) 
                    || (span2.Item1 <= span1.Item2 && span2.Item2 >= span1.Item2)
                ));
            }
        }
