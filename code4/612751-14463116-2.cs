    public interface IImageWrapper
    {
    	object RawImage { get; }
    }
    
    public class PictureBoxImageWrapper : IImageWrapper
    {
    	public object RawImage { get; private set; }
    	
    	public PictureBoxMyImage(PictureBox image)
    	{
    		this.RawImage = image;
    	}
    }
    
    public class DataGridViewImageCellImageWrapper : IImageWrapper
    {
    	public object RawImage { get; private set; }
    	
    	public DataGridViewImageCellImageWrapper(DataGridViewImageCell image)
    	{
    		this.RawImage = image;
    	}
    }
