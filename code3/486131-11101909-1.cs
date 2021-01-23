    class Program
    {
        static void Main(string[] args)
        {
            string xml = "<Product ID=\"41172\" Description=\"2 Pers. With Breakfast\" NonRefundable=\"YES\" StartDate=\"2010-01-01\" EndDate=\"2010-06-30\" Rate=\"250.00\" Minstay=\"1\" />";
            XmlSerializer ser = new XmlSerializer(typeof(Product));
            using(MemoryStream memStream = new MemoryStream())
            {
                byte[] data = Encoding.Default.GetBytes(xml);
                memStream.Write(data, 0, data.Length);
                memStream.Position = 0;
                Product item = ser.Deserialize(memStream) as Product;
                Console.WriteLine(item.Description);
            }
        }
    }
