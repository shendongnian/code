    private static bool Populate(int yPoint, int position)
    {
        int xPoint = 0;
    
        ComboBox cb;
        Action positionFunction;
        if (position == 1)
        {
                positionFunction = () => { 
                        xPoint += cb.Width + 12;
                        yPoint = 0;
                };
        }
        else if (position ==2)
        {
                positionFunction = () => { yPoint += cb.Height + 12; };
        }
        else
        {
                throw new Exception("Invalid position");
        }
    
        foreach (var item in collection)
        {
            cb = AddControl_Combo(item, xPoint, yPoint);
    
            positionFunction();
        }
    
        return true;
    }
