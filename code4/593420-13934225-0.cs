    pictureBox1.Invoke(new MethodInvoker(delegate()
                         {                             
                           if (!pictureBox1.IsDisposed) 
                           {                      
                               pictureBox1.BackgroundImage = (Image)buf;
                           }
                         }));
