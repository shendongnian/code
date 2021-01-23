               while (!read.EndOfStream)
               {
                   string line = read.ReadLine();
                   string[] splitline = line.Split('|');
                   Types t = new Types();
                   Int64 num;
                   if(Int64.TryParse(splitline[0].Trim(), out num))
                   {
                        t.nbr = num;
                        if(splitline.Length > 1)
                        {
                             string[] parts = splitline[1].Split(',');
                             t.addr = (parts.Length > 2 ? parts[2] : "");
                        }
                        List.Add(t);
                   }
               }
