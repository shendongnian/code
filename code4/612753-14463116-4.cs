    public class MyDisplayClass
    {
    	private List<IImageWrapper> Images = new List<IImageWrapper>();
    	
    	public void AddImage(IImageWrapper image)
    	{
    		Images.Add(image);
    	}
    	
    	private void AddImageToContainer(IImageWrapper image)
    	{
    		object rawImage = image.RawImage;
    		
    		if (rawImage is PictureBox)
    			AddImageToContainerImpl((PictureBox)rawImage);
    		else if (rawImage is DataGridViewImageCell)
    			AddImageToContainerImpl((DataGridViewImageCell)rawImage);
    		else
    			throw new NotSupportedException();
    	}
    	
    	private void AddImageToContainerImpl(PictureBox image)
    	{
    		//add to container
    	}
    	
    	private void AddImageToContainerImpl(DataGridViewImageCell image)
    	{
    		//add to container
    	}
    }
