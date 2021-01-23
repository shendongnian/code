    public bool IsValidNamespace(string input)  
            {  
                //Split the string from '.' and check each part for validity  
                string[] strArray = input.Split('.');  
                foreach (string item in strArray)  
                {                  
                    if (! CodeGenerator.IsValidLanguageIndependentIdentifier(item))  
                        return false;  
                }  
                return true;   
            }
