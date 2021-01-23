    var orderedTypes = new List<MessageType>() {        
                MessageType.Boo,
                MessageType.Bar,
                MessageType.Foo,
                MessageType.Doo,
        };
    messages.OrderBy(m => orderedTypes.IndexOf(m.MessageType)).ToList();
