           List<String> strList = new List<String>();
            strList.Add("Axxxx");
            strList.Add("Byyyy");
            strList.Add("Czzzz");
            Dictionary<String, String> dicList = strList.ToDictionary(x => x.Substring(0, 1));
            Console.WriteLine(dicList["A"]);
