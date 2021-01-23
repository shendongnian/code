     private List<string> messages = new List<string>(MAX_ITEMS);
     private const int MAX_ITEMS = 20;
     private void userAddMessege(string message)
     {
            messages.Add(message);
            if (messages.Count > MAX_ITEMS) 
            {
                messages.RemoveAt(0);
            }
      }
