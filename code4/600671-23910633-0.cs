    // Try disabling the "AutoSize"-property, and use the panels' sizes
    label.AutoSize = false;
    label.Width = yourRedPanel.Width;
    label.Height = yourRedPanel.Height;
    label.TextAlign = ContentAlignment.MiddleLeft;
    label.AutoEllipsis = true;
    // Check that "new_X_location"-variable is not negative or 
    // too big to move the label out of the viewable area
    label.Location = new System.Drawing.Point(new_X_location, label.Location.Y);
    // Check that some_string.Length is as great or greater than given Substring length argument
    label.Text = some_string.Substring(0, 2200);
    // The max font size is the biggest possible value of float
    Font testFont = new Font("Arial", float.MaxValue);
    // If this doesn't help, wrap your code to try-catch block
    // Run the code line by line (F10), and see where it jumps to "catch",
    // if there occurs errors
    try
    {
       // Code here
    }
    catch (Exception ex) { MessageBox.Show(ex.Message); }
