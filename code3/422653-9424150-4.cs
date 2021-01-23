    private void _LoadGalleryImages() {
	    PhotoGalleryImageCollection images = PhotoGalleryImages.GetPhotoGalleryImages();
	    foreach(PhotoGalleryImage image in images) {
		    Panel panel = new Panel();
		    panelPhotoContainer.Controls.Add(panel);
		    ImageButton displayImage = new ImageButton();
		    panel.Controls.Add(displayImage);
		    displayImage.ID = string.Format("ImageButton{0}", image.PhotoGalleryImageId);
		    displayImage.ImageUrl = "Some URL";
		    displayImage.AlternateText = displayImage.ToolTip = image.ImageName;
		    if(!_IsSettingPrimaryPhotoMode) {
			    displayImage.OnClientClick = "showPopup(); return false;";
		    }
		    else {
			    // handles the image button command wireup
			    displayImage.Command += new CommandEventHandler(displayImage_Command);
			    displayImage.CommandArgument = image.PhotoGalleryImageId.ToString();
		    }
	    }
    }
