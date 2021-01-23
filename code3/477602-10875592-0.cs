            var items = (from c in
                             (from line in sample
                              let columns = line.Split(';')
                              where columns[0] == "US"
                              select new
                                         {
                                             City = columns[1].Trim(),
                                             State = columns[2].Trim(),
                                             County = columns[3].Trim(),
                                             ZipCode = columns[4].Trim()
                                         })
                         select c);
            foreach (var i in items.GroupBy(an => an.City + "," + an.State))
            {
                Console.WriteLine("{0} ({1})",i.Key, i.Count());
                foreach (var j in i.GroupBy(an => an.ZipCode))
                {
                    Console.WriteLine(" - {0} ({1})", j.Key, j.Count());
                }
            }
