    private void button1_Click(object sender, EventArgs e)
    {
        if (CurrentClicks < MaximumClicks) //Continue if CurrentClicks is less than 5
        {
            string FilesPath = @"D:\Resources\International"; //Replace this with the targeted folder
            string FileExtensions = "*.png"; //Applies only to .png file extensions. Replace this with your desired file extension (jpg/bmp/gif/etc)
            List<string> ItemsInFolder = new List<string>(); //Initialize a new Generic Collection of name ItemsInFolder as a new List<string>
            foreach (string ImageLocation in Directory.GetFiles(FilesPath, FileExtensions)) //Get all files in FilesPath creating a new string of name ImageLocation considering that FilesPath returns a directory matching FileExtensions considering that FileExtensions returns a valid file extension within the targeted folder
            {
                ItemsInFolder.Add(ImageLocation); //Add ImageLocation to ItemsInFolder
            }
            Random Rnd = new Random(); //Initialize a new Random class of name Rnd
            int ImageIndex = Rnd.Next(0, ItemsInFolder.Count); //Initialize a new variable of name ImageIndex as a random number from 0 to the items retrieved count
            pictureBox1.Load(ItemsInFolder[ImageIndex]); //Load the random image based on ImageIndex as ImageIndex belongs to a random index in ItemsInFolder
            CurrentClicks++; //Increment CurrentClicks by 1
        }
        else
        {
            //Do Something (MaximumClicks reached)
        }
    }
