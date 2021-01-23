    private string MakeFilenameValid(string filename, char replacment)
    {
        //
        //-- Get array with invalid chars for filenames
        //
        char[] legalChars = Path.GetInvalidFileNameChars;
        StringBuilder validFilename = new StringBuilder();
        //
        //-- Go through each char in filename and check if the char is
        //   in our array of invalid chars. If it is, replace it
        //
        foreach (char c in filename) {
    	    if (legalChars.Contains(c)) {
    	        validFilename.Append(replacment);
    	    } else {
    	        validFilename.Append(c);
    	    }
        }
        //
        //-- Return filename
        //
        return validFilename.ToString;
    
    }
