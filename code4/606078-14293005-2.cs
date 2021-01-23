       StringBuilder sb = new StringBuilder();
       int rowCounter = 0;
       foreach (DataRow row in dt.Rows)
       {
            rowCounter++;
            longupdate = Convert.ToDateTime(dt.Rows[0]["Long MSDS Update"]);
            shortupdate = Convert.ToDateTime(dt.Rows[0]["Short MSDS Update"]);
            TimeSpan longsince = DateTime.Now.Subtract(longupdate);
            int longyears = (int)(longsince.Days / 365.25);
            TimeSpan shortsince = DateTime.Now.Subtract(shortupdate);
            int shortyears = (int)(shortsince.Days / 365.25);
            if (longyears <= 4.5) 
            {
                string longmsdsname = Convert.ToString(row["Name"]);
                sb.AppendFormat("Long Msds {0}  must be updated\r\n", longmsdsname);
            }
            if (shortyears <= 4.5)
            {
                string shortmsdsname = Convert.ToString(row["Name"]);
                sb.AppendFormat("Short Msds {0}  must be updated\r\n", shortmsdsname);
            }
            // If we have errors, show them and reset the builder for the next loop
            if(sb.Length > 0)
            {
                 string msg = string.Format("Error in row {0}\r\n{1}", 
                                             rowCounter.ToString(), sb.ToString());
                 MessageBox.Show(msg);
                 sb.Length = 0;
            }
        }
