    private void _LoadGalleryImages() {
    	panelPhotoContainer.Controls.Clear();
	    PhotoGalleryImageCollection images = PhotoGalleryImages.GetPhotoGalleryImages();
	    foreach(PhotoGalleryImage image in images) {
		    ImageButton displayImage = new ImageButton();
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
	    }
    }
