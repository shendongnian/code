        while (!sStreamReader.EndOfStream)
        {
            double a = 0.00;
            int b = 0;
            string sLine = sStreamReader.ReadLine();
            // make sure we have something to work with
            if (String.IsNullOrEmpty(sLine)) continue;
            string[] cols = sLine.Split(',');
            // make sure we have the minimum number of columns to process
            if (cols.Length > 4)
            {
                a = Convert.ToDouble(cols[1]);
                b = Convert.ToInt32(cols[3]);
            }
            // You can now use these here too!
            Console.Write(a);
            Console.WriteLine(b);
            Console.WriteLine();
        }
