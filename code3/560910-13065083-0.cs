            while ((tmp = fin.ReadLine()) != null)
            {
                if (tmp.StartsWith("CM_ "))
                {
                    //string[] tmpList = tmp.Split(new Char[] { ' ', ';' }, StringSplitOptions.RemoveEmptyEntries);
                    var result = tmp.Split(new[] { '"' }).SelectMany((s, i) =>
                    {
                        if (i % 2 == 1) return new[] { s };
                        return s.Split(new[] { ' ', ';' }, StringSplitOptions.RemoveEmptyEntries);
                    }).ToList();
                    if (tmp.EndsWith(";")) break;
                    fin.ReadLine();
                    if (tmp.EndsWith(";"))
                    {
                        result.ToList();
                        break;
                    }
                    else
                    {
                        result.ToList();
                        fin.ReadLine();
                    }
                    foreach (string x in result)
                    {
                        Console.WriteLine(x);
                    }
                } 
