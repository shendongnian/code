    string  item = "";    
    foreach (var i in listBox1.SelectedIndices )
        {
           item += listBox1.Items[(int)i] + Environment.NewLine;
        }
    MessageBox.Show(item);
