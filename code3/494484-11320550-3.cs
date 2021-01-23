        private string[] files;
        private int currentIndex = 0;
        private void initializeImages()
        {
            //Grab directories in your images directory
            string appRoot = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            files = System.IO.Directory.GetFiles(appRoot + @"\images");
            Random rnd = new Random();
            files = files.OrderBy(x => rnd.Next()).ToArray();
        }
        private void setImage()
        {
            pictureBox1.ImageLocation = files[currentIndex];
        }
        private void previousImage()
        {
            currentIndex = currentIndex > 0 ? currentIndex - 1 : 0;
            setImage();
        }
        private void nextImage()
        {
            currentIndex = currentIndex < files.Length - 1 ? currentIndex + 1 : files.Length - 1;
            setImage();
        }
       
