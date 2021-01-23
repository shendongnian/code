    public class BuyEstimateResult
    {
        public string SubTitle { get; set; }
        public string Value { get; set; }
        public string Formulae { get; set; }
        public static implicit operator KeyValue(BuyEstimateResult ber)
        {
            return new KeyValue {Key = ber.SubTitle, Value = ber.Value};
        }
    }
    public class SellerReportClass
    {
        public string Entityname { get; set; }
        public double EntityAmt { get; set; }
        public string Formulae { get; set; }
        public static implicit operator KeyValue(SellerReportClass sell)
        {
            return new KeyValue { Key = sell.Entityname, Value = sell.EntityAmt.ToString(CultureInfo.InvariantCulture)};
        }
    }
    public class KeyValue
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
    public class Program
    {
        static void Main()
        {
            var listB = new List<BuyEstimateResult>
                            {
                                new BuyEstimateResult {SubTitle = "BER1", Value = "BER1_VALUE"},
                                new BuyEstimateResult {SubTitle = "BER2", Value = "BER2_VALUE"}
                            };
            var listS = new List<SellerReportClass>
                            {
                                new SellerReportClass {Entityname = "SELL1", EntityAmt = 1.0},
                                new SellerReportClass {Entityname = "SELL2", EntityAmt = 2.5}
                            };
            foreach (KeyValue kv in listB)
                Console.WriteLine(kv.Key + ":" + kv.Value);
            foreach (KeyValue kv in listS)
                Console.WriteLine(kv.Key + ":" + kv.Value);
        }
    }
