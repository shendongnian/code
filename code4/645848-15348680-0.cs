    public class MyObject
    {
    	private Image img;
        public Image Img
        {
    		get { return img; }
    		set { img = value; }
    	}
    	public MyObject()
    	{
    		Img = Image.FromFile("");
    	}
    }
    
    public class Main
    {
    	MyObject obj = new MyObject();
    	//obj.Img = Image.FromFile(""); //if u want
    	Image image = obj.Img;
    }
