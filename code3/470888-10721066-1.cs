        using (StreamReader file = new StreamReader(@"C:\Users\Desktop\snpprivatesellerlist.txt"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    char[] delimiter1 = new char[] { '\n' };
                    string[] part1 = line.Split(delimiter1, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < part1.Length; i++)
                    {
                        sepList.Add(part1[i]);     
                        //st = part1[i];                       
                    }
                                       
                }
                file.Close();
            }
            char[] delimiter2 = new char[] { '\t' };
            for (int j = 4; j < sepList.Count; j++)
            {
                st = sepList[j];
                string[] part2 = st.Split(delimiter2, StringSplitOptions.RemoveEmptyEntries);
                alist.Add(part2);             
            }
            //DateTime time = new DateTime();
            //float value = new float();
            string tagname = alist[0][0];
            for (int y = 0; y < alist.Count; y++)
            {
                 if (alist[y][0]==tagname)
	            {
                          alist1.Add(alist[y]);
	            }
                 else
                 {
                     //plot alist1
                     //clear a list1
                     for (int i = 0; i < alist1.Count; i++)
                     {
                         for (int j = 0; i < alist1[i].GetLength(0); i++)
                         {
                             alist1[i][j] = "";
                         }
                     }
                     tagname = alist[y][0];
                 }
                 
            }
