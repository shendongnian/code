       List<int> offsets = new List<int>();
       using (StreamReader reader = new StreamReader("myfile.csv"))
       {
            int offset = 0;
            string line;
            while ((line = reader.ReadLine()) != null)
            {   
                offsets.Add(offset);             
                offset += (line.Length + 2);   // The 2 is for NewLine(\r\n)
            }
            offsets.Add(offset);  // pick up the last one
        }
 
