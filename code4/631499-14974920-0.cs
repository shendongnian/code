    DateTime Headlinedate;
    try
             {
                 DateTime date = Convert.ToDateTime(txtHeadlinedate.Text.Trim(), Ci);
                 string timestr = DateTime.Now.ToString("MM/dd/yyyy HH:MM:ss");// here is the solution
                 DateTime combinedDate = date.Add(TimeSpan.Parse(timestr));
                 Headlinedate = combinedDate;
             }
             catch {
                 Headlinedate = DateTime.Now;
             }
