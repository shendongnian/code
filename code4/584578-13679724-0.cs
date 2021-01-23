    using (StreamReader sr = new StreamReader("earthquakes.csv"))
        {
            String line;
            List<string> myList = new List<string>();
            while ((line = sr.ReadLine()) != null)
            {
               // Console.WriteLine(line);
                myList.add(line);
            }
        }
