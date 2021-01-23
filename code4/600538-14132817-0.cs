    public void Add (Element e)
            {
                  if (e != owner)
                  {
                      // Not the owner, do your operation
                       childList.Add (e);
                  }
                  else {
                        // Log error message or display warning to user
                     }              
            }
