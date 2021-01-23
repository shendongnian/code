    using System.Drawing;
    
    pubic class TestThis
    {
    	public void Test()
    	{
    	    Image myImage = Image.FromFile("Myfile.png");
    	
    	    int bitDepth = Image.GetPixelFormatSize(myImage.PixelFormat);
    	
    	    if( bitDepth != 1)
    	    {
    	        // Do domething
    	    }
    	}
    }
