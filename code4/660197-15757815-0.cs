    StringBuilder builder = new StringBuilder();
    List<string> messages = new List<string>();
    foreach(char letter in message) {
         if (letter != '^') {
             builder.Add(letter);
         }
         else {
             messages.Add(builder.ToString());
             builder.Clear();
         }
    }
    if (builder.Length != 0) {
       messages.Add(builder.ToString());
    }
    // now your messages list is full of all the different messages!
