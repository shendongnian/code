     private void Image_Tap(object sender, GestureEventArgs e)
        {
            Image mybutton = (Image)sender; // calcifying image based on image taped  
            image1.Source = mybutton.Source; // setting tapped source to image 
            phoneAppservice.State["myValue"] = mybutton.Name; // here saving the name of the image 
        }
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            object value;
            if (phoneAppservice.State.TryGetValue("myValue", out value))
            {
                //retrieving the image name form state and creating new BitMapimage based on this name 
                BitmapImage newImg = new BitmapImage(new Uri("/Gallery;component/Images/"+value+".jpg", UriKind.Relative));
                image1.Source = newImg; 
            }
        }
