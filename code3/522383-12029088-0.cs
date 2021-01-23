    uxRajRadioButton.CheckedChanged += new EventHandler(rb_CheckedChanged);
    uxPaulRadioButton.CheckedChanged += new EventHandler(rb_CheckedChanged);
    ...
    uxRajRadioButton.Tag =new KeyValuePair<string,int>("Raj",0);
    uxPaulRadioButton.Tag =new KeyValuePair<string,int>("Paul",1);
    ....
    private void rb_CheckedChanged(object sender, EventArgs e) 
    {
        if(!(sender is RadioButton))
             return;
           RadioButton myRadio= sender as RadioButton;
          if (myRadio.Checked == true)
          {
            myRadio.Text = (myRadio.Tag as KeyValuePair<string,int>).Key;
            GuySelected = (myRadio.Tag as KeyValuePair<string,int>).Value;
            uxBetNumericUpDown.Maximum =  Guys[GuySelected].Cash;
          }
    }
