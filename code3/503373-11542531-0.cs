    dynamicbutton.Click += OnButtonActionClick();
    
     private void OnButtonActionClick(object sender, ListViewColumnMouseEventArgs e)
    {
        // you clicked the button.
        MessageBox.Show("your current listviewItem - " - e.SubItem.Text)
    }
