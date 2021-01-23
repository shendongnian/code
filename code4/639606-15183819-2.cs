    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                if(ListBox1.SelectedItem!=null)
                {
                   Label1.Text =  ListBox1.SelectedItem.Text;
                   //or you can dynamically create a label and add it to the page
                   Label lbl = new Label();
                   lbl.Text=ListBox1.SelectedItem.Text;
                   MyContainer.Controls.Add(lbl);
                   //where MyContainer is any server side container, HtmlContainerControl  
                   //or HtmlControl 
                }
            }
