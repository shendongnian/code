    public class Order
    {
        public CourceFeeType FeeType;
        public int Amount;
        public int CourseFee;
    
        public void AddFeeTypeDetails(CourceFeeType Fees)
        {
            FeeType = new CourceFeeType();
            FeeType.Code = Fees.Code;
            FeeType.Desc = Fees.Desc;
        }
    
        // Nested class
        public class CourceFeeType
        {
            public String Code;
            public String Desc;
        }
    }
