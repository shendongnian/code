    protected void Button3_Click(object sender, EventArgs e) 
    { 
        //  fillgrid();   <-------------------- from here
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            Label lblteachername = (Label)GridView1.Rows[i].FindControl("lblgridteachername");
            CheckBox status = (CheckBox)GridView1.Rows[i].FindControl("chkgridstatus");
            if (status.Checked == true)
            {    
                string q = "insert into teacher (status) values('"+dayList[i].Date+"') where schid='"+dayList[i].SchId+"'";    
            }                
        }
        fillgrid();    // <-------------------- to  here
    }
