    /*
     * A function to get a Bitmap object directly from a web resource
     * Author: Danny Battison
     * Contact: gabehabe@googlemail.com
     */
    
    /// <summary>
    /// Get a bitmap directly from the web
    /// </summary>
    /// <param name="URL">The URL of the image</param>
    /// <returns>A bitmap of the image requested</returns>
    public static Bitmap BitmapFromWeb(string URL)
    {
    	try {
    		// create a web request to the url of the image
    		HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(URL);
    		// set the method to GET to get the image
    		myRequest.Method = "GET";
    		// get the response from the webpage
    		HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
    		// create a bitmap from the stream of the response
    		Bitmap bmp = new Bitmap(myResponse.GetResponseStream());
    		// close off the stream and the response
    		myResponse.Close();
    		// return the Bitmap of the image
    		return bmp;
    	} catch (Exception ex) {
    		return null; // if for some reason we couldn't get to image, we return null
    	}
    }
