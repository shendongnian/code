    // Using var, since I don't know what class Name and Age actually are
    // I am assuming that they are most likely actually the same class
    // and at least share a base class with .Text and .BackGround
    foreach(var textBox in textBoxes)
    {
        // Could use textBox.Text.Length > 0 here as well for performance
        if(textBox.Text == string.Empty)
        {
            textBox.Background = Brushes.LightSteelBlue;
        }
    }
