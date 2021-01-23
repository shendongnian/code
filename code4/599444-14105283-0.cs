    int counter = 1;
    int UserSuppliedNumber = 0;
    
    // use Int32.TryParse, assuming the user may enter a non-integer value in the textbox.  
    // Never trust user input.
    if(System.Int32.TryParse(TextBox1.Text, out UserSuppliedNumber)
    {
       while ( counter <= UserSuppliedNumber)
       {
           Process.Start("notepad.exe");
           counter = counter + 1;  // Could also be written as counter++ or counter += 1 to shorten the code
       }
    }
    else
    {
       MessageBox.Show("Invalid number entered.  Please enter a valid integer (whole number).");
    }
