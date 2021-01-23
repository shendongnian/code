    private void PreRec_Click(object sender, RoutedEventArgs e)
    {
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (rno > 0)
            {
                rno--;
                listView1.SelectedItem = ds.Tables[0].Rows[rno];
            }
        }
    }
