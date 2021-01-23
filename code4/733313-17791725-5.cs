        static void Main(string[] args)
        {
            CreateReceipt("€1.50", "09.30", "Cash");
        }
        private static void CreateReceipt(string price, string time, string paymentMethod)
        {
            string bodyFile;
            string template = System.IO.Directory.GetCurrentDirectory() + "\\template.html";
            using (StreamReader reader = new StreamReader(template))
            {
                bodyFile = reader.ReadToEnd();
                bodyFile = bodyFile.Replace("<%Price%>", price);
                bodyFile = bodyFile.Replace("<%Time%>", time);
                bodyFile = bodyFile.Replace("<%PaymentMethod%>", paymentMethod);
            }
            FileStream fs = File.OpenWrite(System.IO.Directory.GetCurrentDirectory() + "\\receipt.html");
            StreamWriter writer = new StreamWriter(fs, Encoding.UTF8);
            writer.Write(bodyFile);
            writer.Close();
        }
    }
