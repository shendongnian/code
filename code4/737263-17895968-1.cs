    public void aki(object ab)
    {
        int k = 10; // <---- HERE
        do
            {
               this.SetText1(textBox1.Text +
                              " thread     " + Thread.CurrentThread.GetHashCode() +
                              "               valu=   " + k + Environment.NewLine);
                k--;
            } while (k > 0);
            if (k < 0) Thread.CurrentThread.Abort();    
    }
