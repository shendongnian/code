    XDocument doc = XDocument.Load("In.xml");
    var c = from x in doc.Descendants("order")
            where x.Element("date").Value == "2012.11.20. 1:29:20"
            select new
            {
                Names = string.Join(", ", x.Elements("menuelem")
                                           .Elements("name")
                                           .Select(s => s.Value)),
                Price = x.Elements("menuelem")
                         .Elements("price")
                         .Select(s => decimal.Parse(s.Value))
                         .Sum()
            };
    foreach (var item in c)
    {
        textBox1.Text = string.Format("{0}\tprice:{1}", item.Names, item.Price);
    }
