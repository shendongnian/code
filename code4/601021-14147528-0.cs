    //Make some test data
    var labels = new[] {"A", "B", "C", "D"};
    var rawMessages = new List<Message>();
    for (var i = 0; i < 15; ++i)
    {
        rawMessages.Add(new Message
        {
            Label = labels[i % labels.Length],
            Text = "Hi" + i,
            Timestamp = DateTime.Now.AddMinutes(i * Math.Pow(-1, i))
        });
    }
    //Group the data up by label
    var groupedMessages = rawMessages.GroupBy(message => message.Label);
    //Convert to a dictionary for by-label lookup (this gives us a Dictionary<string, List<Message>>)
    var messageLookup = groupedMessages.ToDictionary(
                //Make the dictionary key the label of the conversation (set of messages)
                grouping => grouping.Key, 
                //Sort the messages in each conversation by their timestamps and convert to a list
                messages => messages.OrderBy(message => message.Timestamp).ToList());
    //Use the data...
    var messagesInConversationA = messageLookup["A"];
    var messagesInConversationB = messageLookup["B"];
    var messagesInConversationC = messageLookup["C"];
    var messagesInConversationD = messageLookup["D"];
