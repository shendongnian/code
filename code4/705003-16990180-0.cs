     boolean textbox1Clickable = false;
     public void textbox1_TextChanged(object sender, EventArgs e)
     {
          string s = textbox1.Text;
          if(TextIsARecognizedWord(s))
          {
              //set the fore color of textbox1 to blue
              //set the font style of textbox1 to underlined
              textbox1Clickable = true;
          }
          else
          {
              //set the fore color of textbox1 to black
              //set the font style of textbox1 to normal (not underlined)
              textbox1Clickable = false;
          }
     }
     
     public void textbox1_Click(object sender, System.EventArgs e)
     {
          if(textbox1Clickable)
          {
               //open your other form based on what is in textbox1.Text
          }
     }
