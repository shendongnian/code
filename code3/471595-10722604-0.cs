    this.Controls[btnAdd.Name].MouseClick += generalMethods.generatePopup();
    
    /* in generalMethods */
    private static int ButtonIndex = 0;
    public MouseEventHandler generatePopup()
    {
       int tempIndex = ButtonIndex++;
       return new MouseEventHandler((sender, ea) => generalMethods.generatePopup(sender, ea, tempIndex));
    }
