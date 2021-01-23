            string filename = @"D:\myfile.log";
            var statistics = File.ReadLines(filename)
                .Where(line => line.StartsWith("Process"))
                .Select(line => line.Split('\t'))
                .GroupBy(items => items[1])
                .Select(g =>
                        new 
                            {
                                Division = g.Key,
                                ZipFiles = g.Sum(i => Int32.Parse(i[2])),
                                Conversions = g.Sum(i => Int32.Parse(i[3])),
                                ReturnedFiles = g.Sum(i => Int32.Parse(i[4])),
                                TotalEmails = g.Sum(i => Int32.Parse(i[5]))
                            });
            Console.Out.WriteLine("Division\tZip Files\tConversions\tReturned Files\tTotal E-mails");
            statistics.ToList().ForEach(d => Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", d.Division, d.ZipFiles, d.Conversions, d.ReturnedFiles,  d.TotalEmails));
