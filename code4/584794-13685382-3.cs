    public void RemoveLast()
    {            
          if (first != null)
          {
               if (first.next == null)
                    first = null;
               else
               {
                    current = first;
    
                    while (current.next != null)
                    {
                        previous = current;
                        current = current.next;
                    }
                    previous.next = null;
               }
          }
    }
