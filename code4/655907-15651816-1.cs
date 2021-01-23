          public void t1_TextChanged(object sender, TextChangedEventArgs e)
    {
            if (String.IsNullOrEmpty(t1.Text.Trim()) == false)
            {
                lb1.Items.Clear();
                foreach (string str in list)
                {
                    if (str.StartsWith(t1.Text.Trim()))
                    {
                        lb1.Items.Add(str);
                    }
                } 
            }
            else if(t1.Text.Trim() == "")
            {
                lb1.Items.Clear();
                foreach (string str in list)
                    {
                        lb1.Items.Add(str);
                    }
                }                         
            }                
