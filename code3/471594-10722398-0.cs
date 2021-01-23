    for (int i = 0; i < 42; i++)
    {
        this.Controls[name].MouseClick += (sender, e) =>
        {
            int index = i;
            generalMethods.generatePopup(sender, e, index);
        }
    }
