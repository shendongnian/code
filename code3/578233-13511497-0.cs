    protected override void OnMouseClick(MouseEventArgs e)
    {
        base.OnMouseClick(e);
        int destX = e.X;
        int destY = e.Y;
        backgroundworker1.cancelasync()
        
            HasArrived = false;
        
        while (HasArrived == false)
        {
        moveImage(destX, destY, pictureBox1);
            if (pictureBox1.Left == destX && pictureBox1.Top == destY)
            {
                HasArrived = true;
                backgroundworker1.startworkasync();
            }
        }
    }
    backgroundworker1_dowork(eventhandler blabla...)
    {
     while (HasArrived == true)
         {
                    randomMove(pictureBox1);
                    hungry1 += 1;
          }
    }
