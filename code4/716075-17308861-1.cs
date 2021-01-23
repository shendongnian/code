    var orderMap = new Dictionary<MessageType, int>() {
        { MessageType.Boo, 0 },
        { MessageType.Bar, 1 },
        { MessageType.Foo, 2 },
        { MessageType.Doo, 3 }
    };
    var orderedList = messageList.OrderBy(m => orderMap[m.MessageType]);
