    protected void FButton_Click(object sender, EventArgs e)
        {
            int sum=0;
            
            foreach(ListItem item in CBL_categ.Items)
            {
              if(item.Selected){
                 sum++;
              }             
            }
 
            statusLabel.Text += " " + sum;
        }
