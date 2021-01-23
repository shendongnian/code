    private static double ScaleY(Joint joint)
    {
        double y = ((SystemParameters.PrimaryScreenHeight / 0.4) * -joint.Position.Y) + (SystemParameters.PrimaryScreenHeight / 2);
        return y;
    }
    private static void ScaleXY(Joint shoulderCenter, bool rightHand, Joint joint, out int scaledX, out int scaledY)
    {
        double screenWidth = SystemParameters.PrimaryScreenWidth;
        double x = 0;
        double y = ScaleY(joint);
        // if rightHand then place shouldCenter on left of screen
        // else place shouldCenter on right of screen
        if (rightHand)
        {
            x = (joint.Position.X - shoulderCenter.Position.X) * screenWidth * 2;
        }
        else
        {
            x = screenWidth - ((shoulderCenter.Position.X - joint.Position.X) * (screenWidth * 2));
        }
        if (x < 0)
        {
            x = 0;
        }
        else if (x > screenWidth - 5)
        {
            x = screenWidth - 5;
        }
        if (y < 0)
        {
            y = 0;
        }
        scaledX = (int)x;
        scaledY = (int)y;
    }
