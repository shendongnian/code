    if (dataGrid1.SelectedItems.Count > 0)    //when selection applied..
      {
       for (int i = 0; i < dataGrid1.SelectedItems.Count; i++) //go row by row in selected column above
          {
           try
             {
              System.Data.DataRowView selectedFile = (System.Data.DataRowView)dataGrid1.SelectedItems[i];
              string str = Convert.ToString(selectedFile.Row.ItemArray[listBox1.SelectedIndex]);
              graphValue.Add(str);
             }
           catch (Exception ex)
             { System.Windows.MessageBox.Show(ex.Message, "error"); }
          }
    
