    private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
    {
       int kkk = comboBox1.Items.Count;
    
       string path = File.ReadAllText("F:\\kmm.txt");
       string[] y = path.Split('\n');
       // clear all existing items first
       comboBox1.Items.Clear();
       foreach (string kk in y)
       {
          comboBox1.Items.Add(kk);
       }
       // comboBox1.Items.Clear();
       string km = comboBox1.SelectedItem.ToString();
       wb.Navigate(km);
    }
