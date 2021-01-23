            public bool ValidateText(String strName)
            {
                try
                {
                    // declaring string variable here
                    String strpattern;
                    // regex pattern setting 
                    strpattern = @"^[a-zA-Z][a-zA-Z0-9']{20}$";
                    // checking for matching with given string here
                    if (!Regex.Match(strName, strpattern))
                    {
                      return false;
                    }
                    else
                      return true;
                }
                catch (Exception ex)
                {
                    ////handle exception
                }
            }
