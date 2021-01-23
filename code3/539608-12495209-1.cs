    this.btn1.Click += new System.EventHandler(Generic_Click); //the same delegate
    this.btn2.Click += new System.EventHandler(Generic_Click);
    this.btn3.Click += new System.EventHandler(Generic_Click);
    ....
      
    private void Generic_Click(object sender, EventArgs e)
    {
         if(  ((Button)sender).Name == "btn1")
         {
            ....
         }
         else if(  ((Button)sender).Name == "btn2")
         {
            ....
         }
         else if(  ((Button)sender).Name == "btn3")
         {
            ....
         }
    
       
    }
