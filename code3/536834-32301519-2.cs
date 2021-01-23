    private void controlName_MouseUp(object sender, MouseEventArgs e)
    {
        s.Stop();
        //determine time you want . but take attention it's in millisecond
        if (s.ElapsedMilliseconds <= 700 && s.ElapsedMilliseconds >= 200)
        {
            //you code here.
        }           
        s.Reset();           
    }
