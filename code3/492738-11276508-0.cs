    public void Button1_Click(object sender, ClickEventArgs e)
    {
         //get the values of both boxes
         string value1 = TextBox1.Text.Trim();
         string value2 = TextBox2.Text.Trim();
    
         //split the value from the source box on its new line characters
         string[] parts = value1.split(Environment.NewLine);
         string last_line = parts[parts.length -1];
    
         //add the last row from the source box to the destination box
         value2 += (Environment.NewLine + last_line);
         
         //set the last_line in the source to an empty string
         parts[parts.Length -1] = String.Empty;
      
         //put the new values back in their text boxes
         TextBox1.Text = String.Join(Environment.NewLine, parts).Trim();
         TextBox2.Text = value2;
    }
