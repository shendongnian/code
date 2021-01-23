        string[] times = { "07:00", "07:15", "07:30", "07:45", "08:00", "08:15", "08:30", "09:00", "09:15", "09:30", "09:45", "10:00", "10:15", "10:30", "11:15" };
        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime prevDt = new DateTime(1);
            string prevString = "";
            
            StringBuilder output = new StringBuilder("UserXyz Deleted ");
            foreach (string time in times)
            {
                
                DateTime dt = DateTime.ParseExact(time,"hh:mm", CultureInfo.InvariantCulture);
                if (dt.Subtract(prevDt).TotalMinutes > 15)
                {
                    if (prevString != "")
                        output.Append(" " + prevString + ",");
                    output.Append(" " + time + " -");
                }
                prevString = time;
                prevDt = dt;
            }
            output.Remove(output.Length - 1, 1);
            MessageBox.Show(output.ToString());
        }
