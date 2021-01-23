     protected void myRepeater_ItemDataBound(Object sender, RepeaterItemEventArgs e)
        { 
            
            //*** Level ID ***//
            Label lblLevelID = (Label)(e.Item.FindControl("lblLevelID"));
            if ((e.Item.FindControl("lblLevelID") != null))
            {
                lblLevelID.Text = DataBinder.Eval(e.Item.DataItem, "LevelID").ToString();
                strLevelID = lblLevelID.Text;
                //MyArr[Convert.ToInt16(In), 0] = strLevelID;
            }
            //*** Selected ***//
            CheckBox chkSelected = (CheckBox)(e.Item.FindControl("chkSelected"));
            if ((e.Item.FindControl("chkSelected") != null))
            {
                if (DataBinder.Eval(e.Item.DataItem, "Selected").ToString() == "True")
                {
                    chkSelected.Checked = true;
                    if (chkSelected.Checked)
                    {
                        UpdateData0();
                    }
                }
                else
                {
                    chkSelected.Checked = false;
                    if (chkSelected.Checked)
                    {
                        UpdateData1();
                    }
                }
                
            }
