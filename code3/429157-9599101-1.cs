    public class ImageProcessor
    {
    	private readonly Image _primaryMarkerSymbol;
    
    	public ImageProcessor(BitmapImage primaryMarkerSymbol)
    	{
    		_primaryMarkerSymbol = Image.FromFile(primaryMarkerSymbol.UriSource.ToString());
    	}
    
    	public Bitmap ProcessImage(string fileName)
    	{
    		var img = new Bitmap(fileName);
    		Graphics g = Graphics.FromImage(img);
    		g.DrawImage(_primaryMarkerSymbol);
    		g.Flush();
    
    		return img;
    	}
    }
