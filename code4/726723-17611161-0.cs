    private Point positining(Button curButton)
    {
        Point outPoint = new Point();
    
        if(curButton == button1)
        {
            outPoint.X = groupBox2.Left + button2.Right + 20;
            outPoint.Y = groupBox2.Top + button2.Bottom - 20;
        }
        else if (curButton == button2)
        {
            outPoint.X = groupBox2.Left + button1.Left - 20;
            outPoint.Y = groupBox2.Top + button1.Top + 20;
        }
    
        return outPoint;
    }
