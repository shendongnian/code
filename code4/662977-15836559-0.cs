    private Keys[] numericKeys =
            {
                 Keys.D1,
                 Keys.D2,
                 Keys.D3,
                 Keys.D4,
                 Keys.D5,
                 Keys.D6,
                 Keys.D7,
                 Keys.D8,
                 Keys.D9,
                 Keys.D0,
                 Keys.NumPad0,
                 Keys.NumPad1,
                 Keys.NumPad2,
                 Keys.NumPad3,
                 Keys.NumPad4,
                 Keys.NumPad5,
                 Keys.NumPad6,
                 Keys.NumPad7,
                 Keys.NumPad8,
                 Keys.NumPad9
    };
    
    ...
    
    bool isDigit = numericKeys.Contains(e.KeyCode);
