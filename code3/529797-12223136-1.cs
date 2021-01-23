        FacebookMessage faceMsg = null;
        var values = result.Values;
        var TotalResult = (((System.Collections.Generic.Dictionary<string, object>.ValueCollection)values).ToList()[0]);
        var TotalMessagesData = (JsonArray)TotalResult;
        if (TotalMessagesData != null)
        {
            foreach (var Messages in TotalMessagesData)
            {
                faceMsg= new FacebookMessage();
                faceMsg.Message = (((JsonObject)Messages)["body"]).ToString();
                faceMsg.SenderID = Convert.ToInt64(((JsonObject)Messages)["author_id"]);
                faceMsg.AddresseeID = Convert.ToInt64(((JsonObject)Messages)["viewer_id"]);
                var MessageSecond = (((JsonObject)Messages)["created_time"]).ToString();
                var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                faceMsg.CreatedDate = dateTime.AddSeconds(double.Parse(MessageSecond));
                result = objFacebookClient.Get("fql",
       new { q = "SELECT name FROM user WHERE uid = " + faceMsg.SenderID });
                
                var values = result.Values;
                faceMsg.SenderName = values.name; // Not tested, but should be something like that.
                result = objFacebookClient.Get("fql",
       new { q = "SELECT name FROM user WHERE uid = " + faceMsg.AddresseeID });
                
                var values = result.Values;
                faceMsg.AddresseeName= values.name; // Not tested, but should be something like that.
                faceMsgList.Add(objFacebookMessage);
            }
        }
