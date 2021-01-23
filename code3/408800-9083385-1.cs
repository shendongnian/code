    protected void LoadCalendar(object sender, EventArgs e)
    {
       
       …
       foreach (ListItem item in WeekCheckBox.Items)
       {
          item.Attributes.Add("onclick", "calculateStudyTime()");
       }
          …
    }
