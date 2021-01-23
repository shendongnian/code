    private void btnViewList_Click(object sender, EventArgs e)
    {
        using(Form2 f2 = new Form2())
        {
            if(DialogResult.OK == f2.ShowDialog())
            {
                // At this point f2 is still in memory but it is hidden
                // You could read the public properties exposed by the Form2
                string name = f2.Name;
                string age = f2.Age;
                string gender = f2.Gender;
            }
        } // <- At this point the f2 instance is closed and ready for GC 
    }
