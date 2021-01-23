    public void RemoveLast()
    {            
          if (first != null)//there is no point in removing since the list is empty
          {
               if (first.next == null) //situation where list contains only one node
                    first = null;
               else //all other situations
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
