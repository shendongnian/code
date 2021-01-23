            string str;
            string PID;
            string PN;
            string UP;
            string DIS;
            string STK;
            string CSVFilePathName = @"C:\admin.csv";
            string[] Lines = File.ReadAllLines(CSVFilePathName);
            File.Delete(CSVFilePathName);
            StreamWriter sw = new StreamWriter(CSVFilePathName", true);
                PID = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[0].Controls[0])).Text;
                PN = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text;
                UP = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text;
                DIS = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[3].Controls[0])).Text;
                STK = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[4].Controls[0])).Text;
            foreach (string li in Lines)
            {
                string[] Fields = li.Split(',');
                if(PID==Fields[0])
                {                                                                     
                    str = PID + "," + PN + "," + UP + "," + DIS + "," + STK;                                 
                }
                else
                {
                    str = Fields[0] + "," + Fields[1] + "," + Fields[2] + "," + Fields[3] + "," + Fields[4];                 
                }
                sw.WriteLine(str);
            }
            sw.Flush();
            sw.Close();
