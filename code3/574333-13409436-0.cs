    public void DrawHangMan(Graphics dM, int guessesRemaining)
    {
        Pen blackPen = new Pen(Brushes.Black);
        Pen deathPen = new Pen(Brushes.Red);
        deathPen.Width = 2.0F;
        if (guessesRemaining < 8)
        {
            dM.DrawEllipse(blackPen, 94, 75, 60, 60);//head
        }
        if (guessesRemaining < 7)
        {
            dM.DrawLine(blackPen, 124, 210, 124, 135);//body
        }
        if (guessesRemaining < 6)
        {
            dM.DrawLine(blackPen, 123, 170, 65, 145);//left arm
        }
        if (guessesRemaining < 5)
        {
            dM.DrawLine(blackPen, 123, 170, 181, 145); //right arm
        }
        if (guessesRemaining < 4)
        {
            dM.DrawLine(blackPen, 123, 210, 65, 255);//left leg
        }
        if (guessesRemaining < 3)
        {
            dM.DrawLine(blackPen, 123, 210, 181, 255);//right leg
        }
        if (guessesRemaining < 2)
        {
            dM.DrawEllipse(blackPen, 105, 93, 10, 10); //left open eye
            dM.DrawEllipse(blackPen, 133, 93, 10, 10); //right open eye
        }
        if (guessesRemaining < 1)
        {
            dM.DrawLine(deathPen, 102, 104, 118, 92);//left eye dead
            dM.DrawLine(deathPen, 118, 104, 102, 92);
            dM.DrawLine(deathPen, 130, 104, 146, 92);//right dead eye
            dM.DrawLine(deathPen, 146, 104, 130, 92);
        }
    }
