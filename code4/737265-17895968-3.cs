    public void aki(object ab)
    {
        int k = 10; // <---- HERE
        do
            {
               this.SetText1(textBox1.Text +
                              " thread     " + Thread.CurrentThread.GetHashCode() +
                              "               valu=   " + k + Environment.NewLine);
                k--;
            } while (k >= 0); // It should be less than and equal to 0 to print 0.
            if (k < 0) Thread.CurrentThread.Abort();    
    }
