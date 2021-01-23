    // the subject we want to test
                var subject =
    @"/*/////
    
    Copyright content which is a lot goes in here.
    
    Programmer:Tono Nam
    
    Description:This is the description of the file....
    
    /////*/";
    
                // the actual pattern this should be a readonly constant type on a real program cause it never should change
                var pattern =
    @"/*/////
    
    Copyright content which is a lot goes in here.
    
    Programmer:
    
    Description:
    
    /////*/";
    
                // we use this pattern to turn the first subject into the second if we can
                var regexPattern = @"(?s)(/\*/*.+Programmer:)(?<name>[^\r\n]*?)(\r.*Description:)(?<desc>[^\r\n]*)(\r.*?/*\*/)";
    
                // note $1 means group 1 so here we are basically removing the groups name and desc
                var newSubject = Regex.Replace(subject, regexPattern, "$1$2$3");
    
                // at this point if newSubject = pattern we know that the header is formatted correctly!
    
                // Let's see where they are different!
                for (int i = 0; i < pattern.Length; i++)
                {
                    if (pattern[i] != newSubject[i])
                    {
                        throw new Exception("There is a problem at index " + i);
                    }
                }
