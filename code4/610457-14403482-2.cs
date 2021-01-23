               ....       
               while (!read.EndOfStream)
               {
                   string line = read.ReadLine();
                   string[] splitline = line.Split('|', StringSplitOptions.RemoveEmptyEntries);
                   Types t = new Types();
                   Int64 num = 0;
                   if(Int64.TryParse(splitline[0].Trim(), out num))
                   {
                        t.nbr = num;
                        if(splitline.Length > 1)
                        {
                             // If you want the third substring of this second string
                             // i.e the 87678 from 1412|123 Circle st Miami,FL,87678
                             // string[] parts = splitline[1].Trim().Split(',');
                             // t.addr = (parts.Length > 2 ? parts[2] : "");
                             
                             // If you want the whole string, no index 3
                             t.addr = splitline[1].Trim();
                        }
                        List.Add(t);
                   }
               }
