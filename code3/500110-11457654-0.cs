        public enum EnumChangeAmt
        {
            Undetermined,
            Negative,
            Positive,
            ExactlyNull,
        }
    
        public class EnumSwitchSample
        {
            public void EnumSwitch()
            {
                var changeAmt = 0;
    
                var changeAmtType = GetChangeAmt(changeAmt);
    
                switch (changeAmtType)
                {
                    case EnumChangeAmt.Negative:
                    {
                        break;
                    }
                    case EnumChangeAmt.Positive:
                    {
                        break;
                    }
                    case EnumChangeAmt.ExactlyNull:
                    {
                        break;
                    }
                    case EnumChangeAmt.Undetermined:
                    default:
                    {
                        // do something about it
                        break;
                    }
                }
            }
    
            public EnumChangeAmt GetChangeAmt(int changeAmt)
            {
                if (changeAmt < 0)
                {
                    return EnumChangeAmt.Negative;
                }
    
                if (changeAmt > 0)
                {
                    return EnumChangeAmt.Positive;
                }
    
                if (changeAmt == 0)
                {
                    return EnumChangeAmt.ExactlyNull;
                }
    
                return EnumChangeAmt.Undetermined;
            }
        }
