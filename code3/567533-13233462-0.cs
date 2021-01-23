    for (int i = 0; i < 8; i++)
    {
        Label Dice = new Label();
        Dice.Name = "Dice" + (i + 1).ToString();
        Dice.HorizontalAlignment = HorizontalAlignment.Left;
        //fill the rest of the properties
        //...
        //you need to add the label to your parent control
        myCanvas.Children.Add(Dice); 
    }
