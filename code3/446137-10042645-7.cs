    public string GetActiveInactiveImg(Boolean IsFavirated)
        {
            string retVal = "~/images/buttons/StarEmpty.png";
   
            if (IsFavirated == true)
            {
                retVal = "~/images/buttons/ChangeImage.gif";
            }
	    else 
            {
                retVal = "~/images/buttons/StarEmpty.png";
            }
	    
            return retVal;
        }
