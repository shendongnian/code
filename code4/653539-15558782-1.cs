      public void doStuff()
        {
            AverageValues AVS = new AverageValues();
            AVS.Bull = "Woof";
            string path = "C:\\users\\kjenks11\\Averages.txt";
            FileStream NewFile = File.Create(path);
            List<AverageValues> AV = new List<AverageValues>();
            AV.Add(AVS);
    
            using(StreamWriter writeIt = new StreamWriter(NewFile))
            {
               foreach (var value in AV)
               {
                    writeIt.Write(value.Bull);
               } 
            }
           NewFile.Close();
        }
