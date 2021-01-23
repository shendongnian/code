        var listOfAs = new List<double>();
            var listOfBs = new List<int>();
            while (!sStreamReader.EndOfStream)
            {
               string sLine = sStreamReader.ReadLine();
               // make sure we have something to work with
               if (String.IsNullOrEmpty(sLine)) continue;
               string[] cols = sLine.Split(',');
               // make sure we have the minimum number of columns to process
               if (cols.Length > 4)
               {
                   double a = Convert.ToDouble(cols[1]);
                   listOfAs.Add(a);
                   int b = Convert.ToInt32(cols[3]);
                   listOfBs.Add(b);
               }
            }
    //Here you can use all As and Bs and send them to the other class
    MyClass.DoSomething(listOfAs,listOfBs);
