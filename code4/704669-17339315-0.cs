    /*
     * Load the picturebox in the control 
     */
            public   void UpdatePictureBox( Bitmap BitmapToBeLoaded, PictureBox CurrentPictureBox)
            {
                /*
                 * If the Bitmap or the picturebox are null there is nothing to update: so exit keeping loaded the previous image
                 */
                if (BitmapToBeLoaded == null) return ;
               
                CurrentPictureBox.Image = BitmapToBeLoaded;                // Assign the Bitmap to the control
                /*
                 *  When loading, adapt the control size to the image size to avoid any distortion
                 */
                CurrentPictureBox.Width = BitmapToBeLoaded.Width;          // Adapth width of the control size
                CurrentPictureBox.Height = BitmapToBeLoaded.Height;        // Adapth height of the control size    
    
                /*
                 * Publish events defensively: Book .Net Components, pag. 108
                 */
                try
                {
                    if (null != ImageUpdated) ImageUpdated();    // Fire the event
                }
                catch
                {
                }
                return ;           
            }
