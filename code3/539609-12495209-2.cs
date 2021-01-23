    this.btn1.Click += new System.EventHandler(Generic_Click); //the same delegate
    this.btn2.Click += new System.EventHandler(Generic_Click);
    this.btn3.Click += new System.EventHandler(Generic_Click);
    ....
      
    private void Generic_Click(object sender, EventArgs e)
    {
         var control = (Button)sender;
         if(  control.Name == "btn1")
         {
            ....
         }
         else if(  control.Name == "btn2")
         {
            ....
         }
         else if(  control.Name == "btn3")
         {
            ....
         }
    
       
    }
