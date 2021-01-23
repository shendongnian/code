    //a list where you save all the buttons created
    List<Button> buttonsAdded = new List<Button>();
    private void button2_Click(object sender, EventArgs e)
    {
        Button myText = new Button();
        myText.Tag = counter;
        myText.Location = new Point(x2,y2);
        myText.Text = Convert.ToString(textBox3.Text);
        this.Controls.Add(myText);
        //add reference of the button to the list
        buttonsAdded.Insert(0, myText);
        
    }
    //atach this to a button removing the other buttons
    private void removingButton_Click(object sender, EventArgs e)
    {
        if (buttonsAdded.Count > 0)
        {
            Button buttonToRemove = buttonsAdded[0];
            buttonsAdded.Remove(buttonToRemove);
            this.Controls.Remove(buttonToRemove);
        }
    }
