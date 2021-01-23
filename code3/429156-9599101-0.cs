    public class ImageProcessor
    {
    	private readonly Image _primaryMarkerSymbol;
    
    	public ImageProcessor(BitmapImage primaryMarkerSymbol)
    	{
    		_primaryMarkerSymbol = Image.FromFile(primaryMarkerSymbol.UriSource.ToString());
    	}
    
    	public Bitmap ProcessImage()
    	{
    		Graphics g = Graphics.FromImage(img);
    		g.DrawImage(_primaryMarkerSymbol);
    		g.Flush();
    
    		return img;
    	}
    }
