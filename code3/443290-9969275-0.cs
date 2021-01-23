            List<string> Content = new List<string>();
            List<string> Delimiters = new List<string>();
            
            string sTestString = "mytest/string*isthis**and not/this";
            string sContentString = String.Empty;
            foreach(char c in sTestString) {
                if(c == '/' || c == '*') {
                
                    Delimiters.Add(c.ToString());
                    if(sContentString != String.Empty) {
                    
                        Content.Add(sContentString);
                        sContentString = String.Empty;  
                    }
                }
                else {
                    sContentString += c.ToString();    
                }   
            
            }
            
            if(sContentString != String.Empty) {
            
                Content.Add(sContentString);
            }
 
