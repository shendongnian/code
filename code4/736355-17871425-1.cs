    protected void check_clicked(object sender, EventArgs e)
    {
        CheckBox me = ((CheckBox)sender);
        MenuNode m = ((MySpecialEventArgs)(e)).theVar;
        List<int> checkedIDs = CheckedIDs;
        if (me.Checked == true)
        {
            me.BackColor = System.Drawing.Color.AliceBlue;
            checkedIDs.Add(m.ID, m.ID);
        }
        else
        {
            me.BackColor = System.Drawing.Color.YellowGreen;
            checkedIDs.Remove(m.ID);
        }
        CheckedIDs = checkedIDs;
    }
    protected void button_clicked(object sender, EventArgs e)
    {
        String checkedMenus = "";
    	List<int> checkedIDs = CheckedIDs;
        for (int i=0; i <  checkedIDs.Count ; i++)
        {
            checkedMenus +="'"+ checkedIDs[i].ToString() + "'";
        }
        //Do DB Stuff
    }
