    { 
      //Form init
       panel1.Click += new System.EventHandler(this.panel1_Click);
      ....
    }
    private void panel1_Click(object sender, EventArgs e)
        {
            //The clicked label will be sender.
            Label l = (Label) sender; //Should be a safe cast. Will crash if sender is not a label
        }
