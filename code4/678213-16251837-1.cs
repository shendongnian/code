    // if red then change to blue
    if (label1.BackColor == Color.Red)
    {
        label1.BackColor = Color.Blue;
    }
    // otherwise, if blue then change to red
    // this condition will be checked if first "if" was false
    else if (label1.BackColor == Color.Blue)
    {
        label1.BackColor = Color.Red;
    }
