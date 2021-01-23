    private void _LoadGalleryImages() {
    PhotoGalleryImageCollection images = PhotoGalleryImages.GetPhotoGalleryImages();
        int imageCtrlCounter = 0;
        foreach(PhotoGalleryImage image in images) {
            ImageButton displayImage = new ImageButton() { ID = String.Format("myDisplayImage{0}", imageCtrlCounter) };
            Panel panel = new Panel();
            panelPhotoContainer.Controls.Add(panel);
            displayImage.ImageUrl = "some URL";
            if(!_IsSettingPrimaryPhotoMode) {
                displayImage.OnClientClick = "showPopup(); return false;";
            }
            else {
                displayImage.Command += new CommandEventHandler(displayImage_Command);
                displayImage.CommandName = "ImageButton" + image.PhotoGalleryImageId.ToString();
                displayImage.CommandArgument = image.PhotoGalleryImageId.ToString();
            }
            panel.Controls.Add(displayImage);
            imageCtrlCounter++;
        }
    }
