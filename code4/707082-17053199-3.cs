        public ImageSource Sag_Image
        {
            get
            {
                if (sag_Image != null)
                    return sag_Image;
                 
                //... Etc your code
                 
                sag_Image = //Assign the backing field to use it later.
                sag_Image.Freeze(); //Notice the Freeze() method.
            }
        }
