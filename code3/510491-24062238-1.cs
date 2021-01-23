    private void btnlvdeleterow_Click(object sender, EventArgs e)
    {
          foreach (int i in Listview2.SelectedIndices)
            {
                string test = Listview2.Items[i].Text;
                Listview2.Items.Remove(Listview2.Items[i]);
                SQLiteCommand conn = new SQLiteCommand();
                conn.Connection = DbClass1.GetConnection();
                string del = "delete from UserData where UserName='" + test + "'";
                int result=dbclass1.ExecuteAndReturn(del);
            }
    }
