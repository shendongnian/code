        static void Main(string[] args)
        {
            using (Stream fileStream = new FileStream(@"C:\Nova pasta\file.xml",   FileMode.OpenOrCreate))
            {
                RootDataSet dataset = new RootDataSet();
                dataset.Rows = new List<Rows>();
                Rows Rows1 = new Rows();
                Rows1.column = new List<string>();
                Rows1.column.Add("teste1");
                Rows1.column.Add("teste2");
                dataset.Rows.Add(Rows1);
                //use reflection to get the properties names of the class
                //get the values of the class
                XmlSerializer xmlSerializer = new XmlSerializer(dataset.GetType());
                xmlSerializer.Serialize(fileStream, dataset);
            }
        }
