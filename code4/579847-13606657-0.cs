    //Get the Screen object where the Hwnd handle is
    System.Windows.Forms.Screen screen = System.Windows.Forms.Screen.FromHandle(Hwnd);
    //Create rectangles object
    Rectangle screenBound = screen.Bounds;
    RECT handleRect = new RECT();
    
    //Get dimensions of the Hwnd handle /!\ don't pass a Rectangle object
    if (!GetWindowRect(Hwnd, ref handleRect))
    {
    	//ERROR
    }
    
    //Getting the intersection between the two rectangles
    Rectangle handleBound = new Rectangle(handleRect.Left, handleRect.Top,                 handleRect.Right-handleRect.Left, handleRect.Bottom-handleRect.Top);
    Rectangle intersection = Rectangle.Intersect(screenBound, handleBound);
    //Get the area of the handle
    int formArea = handleBound.Width * handleBound.Height;
    //Get the area of the intersection
    int intersectArea = intersection.Width * intersection.Height;
    //Calculate percentage
    int percentage = intersectArea * 100 / formArea;
