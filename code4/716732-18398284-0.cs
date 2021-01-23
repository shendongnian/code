    FilteredStream stream = new FilteredStream();
    // Create a Token to access Twitter
    IToken token = new Token("userKey", "userSecret", "consumerKey", "consumerSecret");
    // Adding Tracks filters
    stream.AddTrack("HelloMartha");
    stream.AddTrack("TrackNumber2!");
    // Write the Text of each Tweet in the Console
    stream.StartStream(token, x => Console.WriteLine(x.Text));
