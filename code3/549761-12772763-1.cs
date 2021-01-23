            Image[] Files = new Image[3]; // Create a new array of maximum 3 indices
            Files[0] = pictureBox1.Image;
            Files[1] = pictureBox2.Image;
            Files[2] = pictureBox3.Image;
            panel1.BackgroundImage = CombineBitmap(Files); //Add the combined bitmap to the BackgroundImage
