    private static bool Populate(int yPoint, bool flag)
    {
        int xPoint = 0;
        
        foreach (var item in collection)
        {
            var ComboBox cb = AddControl_Combo(item, xPoint, yPoint);
            if(flag)
            {
                xPoint += cb.Width + 12;
                yPoint = 0;
            }
            else
            {
                yPoint += cb.Height + 12;
            }
        }
        return true;
    }
