    protected void LinkButton_Submit_Attendees_Click(object sender, EventArgs e)
    {
            content row = new content();
    foreach (Control item in PlaceHolder_ForEntries.Controls)
    {
        if (item is TextBox)
        {
            string txt = item.ID.ToString(); // String to run RegEx on
            string re1 = ".*?"; // Non-greedy match on filler
            string re2 = "(\\d+)";  // Integer Number 1
            Regex r = new Regex(re1 + re2, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match m = r.Match(txt);
            int id = Convert.ToInt32(m.Groups[1].ToString());
            TextBox txtBox = (TextBox)item;
            if(item.ID.Contains(id.ToString()) && item.ID.Contains("Name"))
            {
                row.name = txtBox.Text;
            }
            else if (item.ID.Contains(id.ToString()) && item.ID.Contains("MemberNo"))
            {
                row.memberNo = txtBox.Text;
            }
            else if (item.ID.Contains(id.ToString()) && item.ID.Contains("Points"))
            {
                row.points = Convert.ToInt32(txtBox.Text);
            }
    if(!string.IsNullOrEmpty(row.name)
      && !string.IsNullOrEmpty(row.memberNo)
      && row.points > 0)){
            rows.Add(row);
            row = new content();
    }
        }
    }
}
