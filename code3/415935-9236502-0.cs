    private void moveMouse(int startX, int endX, int startY, int endY)
    {
    
      this.BeginInvoke(new Action(() => { InvokeMouseMove(startX, endX, startY, endY)
       }));
    }
    
    private void InvokeMouseMove(int startX, int endX, int startY, int endY)
        {
            int newPosX = startX;
            int newPosY = startY;
            while (running)
            {
                Application.DoEvents();
                //this.Cursor = new Cursor(Cursor.Current.Handle);
                Cursor.Position = new Point(newPosX, newPosY);
    
                if (colorCursor.Get(newPosX, newPosY))
                {
                    MyMouse.sendClick();
                    countClicks++;
                    lblStatus.Text = "Klik: " + countClicks;
                }
    
                newPosX += 10;
                if (newPosX > endX)
                {
                    newPosY += 25;
                    newPosX = startX;
                }
                if (newPosY > endY)
                {
                    newPosY = startY;
                }
            }
        }
