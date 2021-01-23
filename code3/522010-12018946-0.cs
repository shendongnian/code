        protected void LOC_LIST2_SelectedIndexChanged(object sender, EventArgs e)
            {
                Session["SavedItem"] =  LOC_LIST2.SelectedItem;
                if (CheckBoxList2.Items.Count > 0)
                {
                    Label7.Visible = true;
                    Label7.Text = "*Save List Before Proceeding";
                }
            }
    
    after you access on value or text
    SelectedItem item = Session["SavedItem"] as SelectedItem;
    if(item !=null)
    {
    string something= item.Value;
    string otherthing =item.Text;
    }
