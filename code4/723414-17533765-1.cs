    public void SaveSlideTest()
    {
    	// New control
    	MySlideClass.Control newControl = new MySlideClass.Control();
    	newControl.Position	= new Point(20,30);
    	newControl.Size		= new Size(75,25);
    	newControl.Text		= "Image1";
    	newControl.TextPosition= new Point(0,25);
    	//ctl.Picture		= new Bitmap("image1.bmp");
    	
    	// Add control to children list
    	List<MySlideClass.Control> childrenControls = new List<MySlideClass.Control>();
    	childrenControls.Add(newControl);
    	
    	// New slide
    	MySlideClass.Slide newSlide = new MySlideClass.Slide();
    	newSlide.Name	= "Slide1";
    	newSlide.Title	= "New Slide";
    	newSlide.Size	= new Size(200,100);
    	// Add child controls to slide
    	newSlide.Children = childrenControls;
    	
    	// Add slide to presentation or 'slideshow'
    	List<MySlideClass.Slide> mySlidePresentation = new List<MySlideClass.Slide>();
    	mySlidePresentation.Add( newSlide );
    	
    	// Save presentation to XML
    	SerializeObject("SavedSlidePresentation.xml",mySlidePresentation);
    }
