    Button.Click += SomeMethod;
    private void SomeMethod(object sender, EventArgs e)
    {
        System.Windows.Forms.Button bt = sender as System.Windows.Forms.Button;
         if (bt != null)
         {
            if (bt.Equals(System.Windows.Forms.MouseButtons.Left))
            {
                    // do something;
             }
         }
    }
