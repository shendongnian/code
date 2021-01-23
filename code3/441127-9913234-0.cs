    protected void SelectedFriends_Click(object sender, EventArgs e)
          {
    
            list.Clear();
    
            foreach (GridViewRow row in GridView1.Rows)
            {
                // Access the CheckBox
                CheckBox cb = (CheckBox)row.FindControl("FriendSelector");
    
                if (cb != null && cb.Checked)
                {
    
                    string friendname = GridView1.Rows[row.RowIndex].Cells[1].Text.ToString();
                    list.Add(friendname);
    
                }
             }
    
    
        }
