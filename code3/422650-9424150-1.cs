    private void _LoadSelectPrimaryImages() {
	    PhotoGalleryImageCollection images = PhotoGalleryImages.GetPhotoGalleryImages();
	    foreach(PhotoGalleryImage image in images) {
		    Control control = panelPhotoContainer.FindControl(string.Format("ImageButton{0}", image.PhotoGalleryImageId));
		    if(control != null) {
			    ImageButton displayImage = (ImageButton)control;
			    displayImage.OnClientClick = "";
		    }
	    }
    }
