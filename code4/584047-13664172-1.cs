    foreach (ListViewItem iiii in listView1.Items)
    {
         int value;
         string text = iiii.SubItems[4].ToString();
         if (!Int32.TryParse(text, out value))
         {
             MessageBox.Show(String.Format("Cannot parse text '{0}'", text));
             continue; // not number was in listview, continue or break
         }
    
         if (value <= tenthousand)
         {
              labelVideoViews2.Text = "GREAT";
              labelVideoViews2.ForeColor = Color.Green;
              break;
         }
    }
