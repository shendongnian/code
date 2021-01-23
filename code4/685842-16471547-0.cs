    DataSet ds = new DataSet();
    ds.Tables.Add(textBox1.Text);  //I did this in Winforms so, your result may vary.
    ds.Tables.Add(textBox2.Text);  //Same here.
    if (ds.HasChanges())  //Check if the DataSet has changes.
       ds.AcceptChanges(); //If it does, commit them.
