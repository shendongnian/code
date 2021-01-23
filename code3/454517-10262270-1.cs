    public Button myText ; // keep public button to assign your new Button 
    
    private void buttonAdd_Click(object sender, EventArgs e)
    {
            myText = new Button();
            myText.Tag = counter;
            myText.Location = new Point(x2,y2);
            myText.Text = Convert.ToString(textBox3.Text);
            this.Controls.Add(myText);
    }
    
    private void buttonRemove_Click(object sender, EventArgs e)
    {
          if(Button != null && this.Controls.Contains(myText))
          {
               this.Controls.Remove(myText);
               myText.Dispose();
          )
    }
