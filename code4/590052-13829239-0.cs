            string x = "";
            using (StreamReader sr = new StreamReader(@"d:\test.txt"))
                x = sr.ReadToEnd();
            var mynewlist = (from v in x.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                             let items = v.Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries)
                             where items.Count() == 5
                             select new
                             {
                                 ID = int.Parse(items[0]),
                                 FamilyN = items[1],
                                 LastN = items[2],
                                 Country = items[3],
                                 Date = DateTime.ParseExact(items[4], "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture)
                             }).GroupBy(X => X.ID).Where(X => X.Count() == 1).Select(X => X.First());//add any condition here
            //mynewlist is a strongly typed List
            string output = "";
            foreach (var item in mynewlist)
                output += item.ID + "," + item.FamilyN + "," + item.LastN + "," + item.Country + "," + item.Date.ToString("MM/dd/yyyy") + "\r\n";
            using (StreamWriter sw = new StreamWriter(@"d:\test.csv"))
                sw.Write(output);
