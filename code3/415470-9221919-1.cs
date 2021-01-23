    Private void MyFunction()
    {
       comboBox1.SelectedIndexChanged -= new EventHandler(TestIt);
       MyComboBox.Text = "New Value";
       comboBox1.SelectedIndexChanged += new EventHandler(TestIt);
    }
    
    private void TestIt(object sender, EventArgs e)
    {
      //do something//
    }
