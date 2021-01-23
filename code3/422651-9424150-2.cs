    private void _ResetGalleryImages() {
	    PhotoGalleryImageCollection images = PhotoGalleryImages.GetPhotoGalleryImages(_photoGalleryId, false, true);
	    foreach(PhotoGalleryImage image in images) {
		    Control control = panelPhotoContainer.FindControl(string.Format("ImageButton{0}", image.PhotoGalleryImageId));
		    if(control != null) {
			    ImageButton displayImage = (ImageButton)control;
			    displayImage.OnClientClick = "showPopup(); return false;";
		    }
	    }
    }
