    private void Form1_KeyUp(object sender, KeyEventArgs e)
    {
        string pressedKey = e.KeyData.ToString();
        if (pressedKey.StartsWith("D")) 
        { 
            pressedKey = pressedKey.Replace("D", "");
            MessageBox.Show(pressedKey);
        }
        if (pressedKey.StartsWith("NumPad"))
        { 
            pressedKey = pressedKey.Replace("NumPad", "");
            MessageBox.Show(pressedKey);
        }
    }
