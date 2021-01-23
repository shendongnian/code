        public class ContiguousDataValue
        {
            public int UpperInt { get; set; }
            public int LowerInt { get; set; }
            public override string ToString()
            {
                return "Upper" + UpperInt + " Lower" + LowerInt; 
            }
        }
    public class ContiguousData 
    {
        LinkedList<ContiguousDataValue> ranges = new LinkedList<ContiguousDataValue>();
        
        public void AddValue(int val)
        {
            for (LinkedListNode<ContiguousDataValue> range = ranges.Last; range != null; range = range.Previous)
            {
                if (val > range.Value.UpperInt)
                {
                    // increment current node if applicable 
                    if (val == range.Value.UpperInt + 1)
                        range.Value.UpperInt = val;
                    else
                        ranges.AddAfter(range, new ContiguousDataValue() { UpperInt = val, LowerInt = val });
                    return;
                }
                else if (val < range.Value.LowerInt)
                {
                    if (val == range.Value.LowerInt - 1)
                    {
                        range.Value.LowerInt = val;
                        return;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            // Anything that reaches this line is either a very new low value, or the first entry
            ranges.AddLast(new ContiguousDataValue() { UpperInt = val, LowerInt = val });
        }
     }
