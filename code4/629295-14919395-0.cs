    // this is in case you want to take them after submitting them to server
    protected void OnPreRender(object sender, EventArgs e) {
          foreach (RepeaterItem item in Repeater1.Items)
          {
             TextBox textBox = (TextBox)item.FindControl("TextBox1");
             if(txtName!=null)
             {
                var textBoxResult = textBox.Text;
             }
          }
    }
    // it is in case you want to put values on load
    foreach (RepeaterItem item in Repeater1.Items)
    {
          TextBox textBox= (TextBox)item.FindControl("TextBox1");
          if(textBox!=null)
          {
              textBox.Text = "Hello";
          }
    }
