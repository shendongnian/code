    //Grab directories in your images directory
            string appRoot = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            string[] files = System.IO.Directory.GetFiles(appRoot + @"\images");    
            Random rnd = new Random();
            files = files.OrderBy(x=>rnd.Next()).ToArray();
            //simple loop for testing
            for (int i = 0; i < files.Length; i++)
            {
                pictureBox1.ImageLocation = files[i];
                //This will sleep the current thread so you can actually see images change.   
                //I wouldn't recommend doing this for your app. have this configurable, or use another 
                //mechanism to time the image switch.
                System.Threading.Thread.Sleep(500);
            }
