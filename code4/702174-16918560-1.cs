    private void btnViewList_Click(object sender, EventArgs e)
    {
        Form2 f2 = new Form2();
        if(DialogResult.OK == f2.ShowDialog())
        {
            string f1 = f2.FocusedItem;
            string f2 = f2.FocusedSubItem1;
            string f3 = f2.FocusedSubItem2;
           
        }
    }
