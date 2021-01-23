    var formattedLine=messageList.AsParallel().AsOrdered().Select((message, index) =>
    {
        ... // Some work here to be done in parallel
        return string.Format(...); // Some formatting here of message using index
    });
