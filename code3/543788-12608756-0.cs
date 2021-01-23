    public class StackOverflow_12608671
    {
        const string XML = @"<Pricing> 
                                <Code>Success</Code> 
                                <PricingQuotes>  
                                    <PricingQuote> 
                                        <ProductName>Conforming 30 Year Fixed</ProductName> 
                                    </PricingQuote> 
                                    <PricingQuote> 
                                        <ProductName>Conforming 20 Year Fixed</ProductName> 
                                    </PricingQuote> 
                                </PricingQuotes>  
                            </Pricing> ";
        public class Pricing
        {
            public string Code { get; set; }
            public List<PricingQuote> PricingQuotes { get; set; }
        }
        public class PricingQuote
        {
            public string ProductName { get; set; }
        }
        public static void Test()
        {
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(XML));
            XmlSerializer xs = new XmlSerializer(typeof(Pricing));
            Pricing p = (Pricing)xs.Deserialize(ms);
            foreach (var q in p.PricingQuotes)
            {
                Console.WriteLine(q.ProductName);
            }
        }
    }
