       Button.MouseClick += SomeMethod;
       private void SomeMethod(object sender, MouseEventArgs e)
       {
            if (!e.Button.Equals(System.Windows.Forms.MouseButtons.Right))
            {
                // do work
            }
       }
