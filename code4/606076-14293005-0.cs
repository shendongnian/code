       StringBuilder sb = new StringBuilder();
       foreach (DataRow row in dt.Rows)
       {
            longupdate = Convert.ToDateTime(dt.Rows[0]["Long MSDS Update"]);
            shortupdate = Convert.ToDateTime(dt.Rows[0]["Short MSDS Update"]);
            TimeSpan longsince = DateTime.Now.Subtract(longupdate);
            int longyears = (int)(longsince.Days / 365.25);
            TimeSpan shortsince = DateTime.Now.Subtract(shortupdate);
            int shortyears = (int)(shortsince.Days / 365.25);
            if (longyears <= 4.5) 
            {
                string longmsdsname = Convert.ToString(dt.Rows[0]["Name"]);
                sb.AppendFormat("Long Msds {0}  must be updated\r\n", longmsdsname);
            }
            if (shortyears <= 4.5)
            {
                string shortmsdsname = Convert.ToString(dt.Rows[0]["Name"]);
                sb.AppendFormat("Short Msds {0}  must be updated\r\n", shortmsdsname);
            }
            // If we have errors, show them and reset the builder for the next loop
            if(sb.Length > 0)
            {
                 MessageBox.Show(sb.ToString());
                 sb.Length = 0;
            }
        }
