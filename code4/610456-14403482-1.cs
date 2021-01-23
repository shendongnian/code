               while (!read.EndOfStream)
               {
                   string line = read.ReadLine();
                   string[] splitline = line.Split('|', StringSplitOptions.RemoveEmptyEntries);
                   Types t = new Types();
                   Int64 num;
                   if(Int64.TryParse(splitline[0].Trim(), out num))
                   {
                        t.nbr = num;
                        if(splitline.Length > 1)
                        {
                             // If you want only the third substring
                             // i.e the 87678 from 1412|123 Circle st Miami,FL,87678
                             // string[] parts = splitline[1].Trim().Split(',');
                             // t.addr = (parts.Length > 2 ? parts[2] : "");
                             
                             // If you want the whole substring
                             t.addr = splitline[1].Trim();
                        }
                        List.Add(t);
                   }
               }
