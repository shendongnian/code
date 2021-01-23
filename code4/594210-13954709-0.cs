    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
      foreach (DataRow dr in ds.Tables[0].Rows)
      {
        DateTime df = (DateTime)dr.Field<DateTime?>("DateFrom");
        DateTime dt = (DateTime)dr.Field<DateTime?>("DateTo");
        if (e.Day.Date == dt.Date)
        {
            Label lbl = new Label();
            lbl.BackColor = System.Drawing.Color.Gray;
            lbl.Text = "Booked From";
            e.Cell.Controls.Add(lbl);
         }
        if (e.Day.Date == df.Date)
        {
            Label lbl = new Label();
            lbl.BackColor = System.Drawing.Color.Gray;
            lbl.Text = "Booked To";
            e.Cell.Controls.Add(lbl);
        }
        //Added Code
        if(e.Day.Date > df.Date && e.Day.Date < dt.Date)
        {
            Label lbl = new Label();
            lbl.BackColor = System.Drawing.Color.Gray;
            lbl.Text = "Day inbetween";
            e.Cell.Controls.Add(lbl);
        }
    } 
