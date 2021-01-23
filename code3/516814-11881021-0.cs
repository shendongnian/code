            string line;
            System.IO.StreamReader file = new System.IO.StreamReader("c:\\test.csv");
            while ((line = file.ReadLine()) != null)
            {
                var arr = line.Split(new char[] { ',' });
                // do your comparison
            }
