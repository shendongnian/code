    using (StreamReader reader = new StreamReader(e.Result)) 
    {
         List<string> lines = new List<string>();
         while (!reader.EndOfStream) 
             lines.Add(reader.ReadLine());
         string prices = lines.First().Split(':');
         List<decimal> listPrices = new List<decimal>();
         List<string> listDates = lines.Last().Split(':').ToList();
         foreach(string s in prices)
            listPrices.Add(double.Parse(s));
         listBox1.ItemsSource = listPrices;
         listBox2.ItemsSource = listDates;
    }
