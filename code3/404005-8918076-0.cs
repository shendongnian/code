    public override void Draw(List<string> menuOptions, int currentSelection, MenuType type)
    {
        Draw("", menuOptions, currentSelection, type, Color.White, Color.Gray, Color.WhiteSmoke, Color.DimGray);
    }
    public void Draw(string menuName, List<string> menuOptions, int currentSelection, MenuType type)
    {
        Draw(menuName, menuOptions, currentSelection, type, Color.White, Color.Gray, Color.WhiteSmoke, Color.DimGray);
    }
    public void Draw(string menuName, List<string> menuOptions, int currentSelection, MenuType type, Color foreNorm, Color backNorm, Color foreSelect, Color backSelect)
    {
        //Actual Draw
    }
