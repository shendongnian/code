        BitmapImage[] iHab;
        
        BitmapImage CreateBitmap(string uri)
            { 
            return new BitmapImage(new Uri(uri));
            }
        BitmapImage[] GetImages()
            {
            string currDir = Directory.GetCurrentDirectory();
            string[] imageUris;
            //Get directory path of myData 
            string temp = currDir + "\\Media\\hcia\\";
            imageUris = Directory.GetFiles(temp, "habitation*.png");
            return imageUris.Select(CreateBitmap).ToArray();  
            }
        private void Rec_hab_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            iHab = GetImages();
            pointer.Source = iHab[7]; // the 7th image : can be manipulated with an i++
        }
