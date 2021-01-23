    Button btn = new Button();
     btn.ID = "btn" + i;
     btn.Text = "Add New";
    btn.Click += new RoutedEventHandler(this.GreetingBtn_Click);
     Panel1.Controls.Add(btn);
     Panel1.Controls.Add(new LiteralControl("<br /><br />"));
    
      void GreetingBtn_Click(Object sender, RoutedEventArgs e)
      {
         create();
      }
