    using (Form1 form = new Form1())
    {
        DialogResult dr = form.ShowDialog();
        if(dr == DialogResult.OK)
        {
            string custName = form.CustomerName;
            SaveToFile(custName);
        }
        
    }
