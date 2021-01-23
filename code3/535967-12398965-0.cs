    private Dictionary<string,string> dictionary = new Dictionary<string,string>();
    
    foreach (var item in feed.Items)
            {
                dictionary.Add(item.Title.Text, item.Links.Text);
                listBox1.Items.Add(item.Title.Text);
                
            }
    private void listBox1_Click(object sender, EventArgs e)
      {   
          string url = dictionary[listBox1.SelectedValue];       
          MessageBox.Show(url);
      }
