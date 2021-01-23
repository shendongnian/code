    public partial class MyImage : Control
    {
    	public MyImage()
    	{
    		InitializeComponent();
    
    		bitmap = new Lazy<Bitmap>(InitializeBitmap);	
    	}
    
    	private Lazy<Bitmap> bitmap;
    	private Bitmap InitializeBitmap()
    	{
    		var myImage = new Bitmap(Width, Height);
    		using(var gr = Graphics.FromImage(myImage))
    		{
    		    gr.FillRectangle(Brushes.BlueViolet, 0, 0, Width, Height);
    		}
    		return myImage;
    	}
    
    	protected override void OnPaint(PaintEventArgs pe)
    	{
    		base.OnPaint(pe);
    
    		pe.Graphics.DrawImage(bitmap.Value, 0, 0);
    	}		
    }
