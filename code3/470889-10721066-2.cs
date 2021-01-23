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
                    SensorProbeDataContainer sensorprobe = new SensorProbeDataContainer();
                    sensorprobe.Setdata(templist);                   
                    sensorprobe.SensorProbe = sensorprobe.data[0][0];
                    ProbeList.Add(sensorprobe.SensorProbe);
                    DateTime.TryParse(sensorprobe.data[0][2], out sensorprobe.StartDate);
                    DateTime.TryParse(sensorprobe.data[(sensorprobe.data.Count - 1)][2], out sensorprobe.EndDate);
                    classcontainer.Add(sensorprobe);
                    tagname = alist[y][0];
                    templist.Clear();                 }
                 
            }
