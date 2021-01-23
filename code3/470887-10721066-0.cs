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
            for (int y = 0; y < alist.Count; y++)
            {
                 string tagname = alist[0][0];
                 if (alist[y][0]==tagname)
	            {
		            var list1 = alist[y].Select(t => new
                             {   Tag = alist[y][0],
                                 TimeStamp = alist[y][2],
                                 value = alist[y][3],
                                 unit = alist[y][4]
                             });  
	            }             
                 
            }
