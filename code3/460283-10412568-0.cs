        if (listDetails.Where(x => { if(Path.GetDirectoryName(x).Contains(fullname))
    			                     {
    					                var file = Path.GetFileName(x);
    					                return file.Contains(namegiventosearch) && file.Contains("sd");
    				                 }
    				                 else 
    				                 {
    						            return false;
    					         }
        }).Count() > 0
        {
             // do Task
        }
    enter code here
