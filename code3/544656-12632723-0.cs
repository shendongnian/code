     private void myEventHandler(object sender, EventArgs e)
     {
       Button b = (Button) sender;
       txtMain.Text = b.ID;
       //
       txtMain.Text = b.Text;
       if(b.ID == "button1")
         doThis();
       else if(b.ID == "button2")
         doThat();
     }
