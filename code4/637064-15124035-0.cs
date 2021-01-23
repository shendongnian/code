      textbox2.Text = textbox1.Text; // set tb2 = tb1
      string[] names = textbox1.Text.Split(','); // i use a comma but use whatever
      // separates the names might just want ' ' for whitespace
      textbox1.Text = System.String.Empty; // clear tb1
      MessageBox.Show("You entered " + names.Count.ToString() + " names."); // show the names count
