    private void Initialize() {
        if (CheckPositions()) {
            ReadPositions();
            MessageBox.Show("Loaded positions", "Go on!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        } else
            MessageBox.Show("Something went wrong trying to read positions.txt\r\nDelete the file and try again.", "Woops", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    private bool CheckPositions() {
        if (File.Exists(Application.StartupPath + @"\positions.txt") && File.ReadAllLines(Application.StartupPath + @"\positions.txt").Length == 6)
            return true;
        else
            if (EnterPositions())
                return CheckPositions();
            else
                return false;
    }
    private bool EnterPositions() {
        bool finished = false;
        MessageBox.Show("To make sure the mouse clicks on the right places when the program runs, you need to run through these 3 steps." +
        "\r\nGo to the site and click OK", "First steps", MessageBoxButtons.OK, MessageBoxIcon.Information);
        TextWriter tw = new StreamWriter(Application.StartupPath + @"\positions.txt",false);
        MessageBox.Show("Please place your mouse on the textfield" + "\r\n and press Enter", "Textbox");
        tw.WriteLine(string.Format("{0,-4:0000} # Textbox X", Cursor.Position.X));
        tw.WriteLine(string.Format("{0,-4:0000} # Textbox Y", Cursor.Position.Y));
        MessageBox.Show("Please place your mouse on the 0 (zero) position of the Slider" + "\r\n and press Enter", "Slider");
        tw.WriteLine(string.Format("{0,-4:0000} # Slider X", Cursor.Position.X));
        tw.WriteLine(string.Format("{0,-4:0000} # Slider Y", Cursor.Position.Y));
        MessageBox.Show("Please place your mouse on the submit button" + "\r\n and press Enter", "Submit");
        tw.WriteLine(string.Format("{0,-4:0000} # Submit X", Cursor.Position.X));
        tw.WriteLine(string.Format("{0,-4:0000} # Submit Y", Cursor.Position.Y));
        tw.Close();
        finished = true;
        return finished;
    }
