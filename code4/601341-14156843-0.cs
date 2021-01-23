    private void listView1_ItemActivate(object sender, EventArgs e)
    {
        try
        {
            string sPath = listView1.SelectedItem.SubItems[0].Text;
            Process.Start(sPath);
        }
        catch(Exception Exc)
        {
            MessageBox.Show(Exc.ToString());
        }
    }
