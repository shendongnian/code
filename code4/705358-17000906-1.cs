    var result = BuildTree(0, GetRequestTreeNodes());
               
     public List<MessageElement> BuildTree(int depth, List<MessageElement> messageElements)
            {
                if (messageElements == null)
                {
                    return null;
                }
                return (
                      from element in BuildGrouping(depth, messageElements)           // Ex:(1, "NetworkControl.AlternateIndexText.Value")
                      let elementId = element.Key                      // get id from message element
    
                      select new MessageElement()
                      {
                          ID = depth,                                  // id of each path  Ex: 1 => "NetworkControl.AlternateIndexText.Value"
                          Name = element.Key,             //name of each tree node to be displayed on tree
                          Children = BuildTree(depth +1,                    //create child from the propertyPath
                            element.ToList<MessageElement>())
                      }
                      ).ToList<MessageElement>();
    
            }
    
            public IEnumerable<IGrouping<string, MessageElement>> BuildGrouping(int depth, List<MessageElement> messageElements)
            {
                string key = string.Empty;
                if (messageElements != null && messageElements.Count > 0)
                {
                    string[] splits = messageElements[0].path.Split('.');
                    if (splits.Length > depth)
                    {
                        key = splits[depth];
                    }
                }
    
                if (string.IsNullOrEmpty(key))
                {
                    return new List<IGrouping<string, MessageElement>>();
                }
    
                return from element in messageElements group element by element.path.Split('.')[depth];
            }
