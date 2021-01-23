    var facebookClient = new FacebookClient(attendee.FacebookToken);
    var parameters = new Dictionary<string, object>
                                     {
                                         {"message", message},
                                         {"place", placeID}
                                     };
    dynamic response = facebookClient.Post("me/feed", parameters);
