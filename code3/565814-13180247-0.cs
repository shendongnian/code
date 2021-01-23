    bool hasAWinner = false;
    // for each line
    for (int i = 0; i < 2; i++)
        Dictionary<Color, int> numberOfbuttonsWithColor = new Dictionary<Color, int>();
        numberOfbuttonsWithColor[Color.Red] = 0;
        numberOfbuttonsWithColor[Color.Yellow] = 0;
        // detect if there is at least two buttons of the same color
        for (int j = 0; j < 3; j++) {
            Color currentButtonColor = buttons[i,j].BackColor;
            numberOfbuttonsWithColor[currentButtonColor]++;
            if (numberOfbuttonsWithColor[currentButtonColor] == 2) {
                hasAWinner = true;
                break;
            }
        }
        if (hasAWinner) break;
    }
    // execute victory actions
    if (hasAWinner) {
        Console.writeline(String.format("Color {0} wins!", currentButtonColor);
    }
            
