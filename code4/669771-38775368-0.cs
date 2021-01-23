    bool change = false;
    private void timer1_Tick(object sender, EventArgs e)
    {
        try
        {
            if (change)
            {
                 InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
                change = false;
            }
            else
            {
                PaintLineToScreen();
                change = true;
            }
        }
        catch (System.Exception caught)
        {
            MessageBox.Show(caught.Message);
        }
    }
