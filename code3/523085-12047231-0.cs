    int a = int.Parse("3E", System.Globalization.NumberStyles.HexNumber);
    int b = int.Parse("32", System.Globalization.NumberStyles.HexNumber);
    
    if (a > b)
        MessageBox.Show("a is greater");
