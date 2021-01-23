    public class MySlideClass
    {
    	public class Control
    	{
    		public Point Position		{ get; set; }
    		public Size	 Size			{ get; set; }
    		public Color Background		{ get; set; }
    		public Color Forground		{ get; set; }
    		public Image Picture		{ get; set; }
    		public string Text			{ get; set; }
    		public float TextSize		{ get; set; }
    		public Point TextPosition	{ get; set; }
    		// ...
    		public float Transparency   { get; set; }
    		public bool  Visible		{ get; set; }
    		
    		public Control()
    		{
    		}
    	}
    	
    	public class Slide
    	{
    		[XmlAttribute]
    		public string Name			{ get; set; }
    		//
    		public string Title			{ get; set; }
    		public Size Size			{ get; set; }
    		public Color Background		{ get; set; }
    		public Color Forground		{ get; set; }
    		public float Transparency   { get; set; }
    		public bool Visible			{ get; set; }
    		
    		public List<Control> Children { get; set; }
    		
    		public Slide()
    		{
    		}
    	}
    	
    	
    	public MySlideClass()
    	{
    	}
    }
