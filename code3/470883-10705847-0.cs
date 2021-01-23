    public class StackOverflow_10705733
    {
        [CollectionDataContract(Name = "invoices", ItemName = "invoice", Namespace = "")]
        public class Invoices : List<int>
        {
            [DataMember(Name = "invoice")]
            public int[] InvoiceIds { get; set; }
        }
        public static void Test()
        {
            DataContractSerializer dcs = new DataContractSerializer(typeof(Invoices));
            string xml = @"<invoices>
                              <invoice>2848</invoice>
                              <invoice>2849</invoice>
                              <invoice>2850</invoice>
                              <invoice>2851</invoice>
                              <invoice>2852</invoice>
                            </invoices>";
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(xml));
            Invoices value = dcs.ReadObject(ms) as Invoices;
            Console.WriteLine(string.Join(",", value));
        }
    }
