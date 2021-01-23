        if (nodes.FirstOrDefault()!=null)
        {
            var o=nodes.FirstOrDefault();
            if (o.InnerText.Equals("Results"))
            {
                foreach (var c in o.SelectNodes("//table"))
                {
                    Console.WriteLine(c.InnerText);             
                }
            }
        }
