    //Grab directories in your images directory
               string appRoot = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            string[] files = System.IO.Directory.GetFiles(appRoot + @"\images");    
            Random rnd = new Random();
            files = files.OrderBy(x=>rnd.Next()).ToArray();
            //I'll use a for loop to simulate how to loop
            for (int i = 0; i < files.Length; i++)
            {
                pictureBox1.ImageLocation = files[i];
                //This will sleep the current thread so you can actually see images change. Not recommended for real life stuff.
                System.Threading.Thread.Sleep(500);
            }
