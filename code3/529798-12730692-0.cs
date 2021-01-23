    public class Facebook
    {
        #region Private Properties
        private string ClientId = System.Configuration.ConfigurationManager.AppSettings["ClientId"];
        private string ClientSecret = System.Configuration.ConfigurationManager.AppSettings["ClientSecret"];
        #endregion
        #region Public Methods
        public string GetLongLifeAccessToken(string ExistingToken)
        {
            try
            {
                string Data = string.Empty;
                string url = string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&client_secret={1}&grant_type=fb_exchange_token&fb_exchange_token={2} ",
                                ClientId, ClientSecret, ExistingToken);
                System.Net.HttpWebRequest request = System.Net.WebRequest.Create(url) as System.Net.HttpWebRequest;
                using (System.Net.HttpWebResponse response = request.GetResponse() as System.Net.HttpWebResponse)
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream());
                    Data = sr.ReadToEnd();
                    Data = HttpUtility.ParseQueryString(Data)["access_token"];
                }
                return Data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Model.FacebookUserMessageInfo> ReadFacebookMailbox(string AuthToken, long? CurrentUserDefaultFacebookId, DateTime? LastProcessedDate, DateTime CurrentDate, int FacebookUserId)
        {
            try
            {
            
                FacebookClient objFacebookClient;
                List<Model.FacebookUserMessageInfo> objFacebookMessageList;
                objFacebookClient = new FacebookClient(AuthToken);
                try
                {
                    objFacebookClient.Get("me");
                }
                catch (Exception ex)
                {
                    throw new Exception(ErrorType.UnableToAuthorizFacebookUser.ToString());
                }
                TimeSpan t = LastProcessedDate.Value - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                int timestamp = (int)t.TotalSeconds;
                dynamic result = objFacebookClient.Get("fql",
                   new { q = "SELECT message_id, author_id, viewer_id, body, created_time FROM message WHERE thread_id IN (SELECT thread_id FROM thread WHERE folder_id = 0) AND created_time >= " + timestamp.ToString() });
                objFacebookMessageList = new List<Model.FacebookUserMessageInfo>();
                if (result != null)
                {
                    Model.FacebookUserMessageInfo objFacebookMessage = null;
                    var values = result.Values;
                    var TotalResult = (((System.Collections.Generic.Dictionary<string, object>.ValueCollection)values).ToList()[0]);
                    var TotalMessagesData = (JsonArray)TotalResult;
                    if (TotalMessagesData != null)
                    {
                        foreach (var Messages in TotalMessagesData)
                        {
                            /*author_id	=	The ID of the user who wrote this message.*/
                            /*viewer_id	=	The ID of the user whose Inbox you are querying*/
                            objFacebookMessage = new Model.FacebookUserMessageInfo();
                            objFacebookMessage.MessageText = (((JsonObject)Messages)["body"]).ToString();
                            long author_id = Convert.ToInt64(((JsonObject)Messages)["author_id"]);
                            long viewer_id = Convert.ToInt64(((JsonObject)Messages)["viewer_id"]);
                            if (author_id == viewer_id)
                            {
                                objFacebookMessage.MessageType = Core.Enum.FacebookMessageType.Sent.ToString();
                            }
                            else
                            {
                                objFacebookMessage.MessageType = Core.Enum.FacebookMessageType.Receive.ToString();
                            }
                            objFacebookMessage.ActionUserID = author_id;
                            objFacebookMessage.FacebookUserId = FacebookUserId;
                            var MessageSecond = (((JsonObject)Messages)["created_time"]).ToString();
                            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                            objFacebookMessage.CreatedDate = dateTime.AddSeconds(double.Parse(MessageSecond));
                            objFacebookMessageList.Add(objFacebookMessage);
                        }
                    }
                }
                if (objFacebookMessageList.Count > 0)
                {
                    objFacebookMessageList = objFacebookMessageList.Where(fm => fm.CreatedDate >= LastProcessedDate && fm.CreatedDate <= CurrentDate).ToList();
                    objFacebookMessageList.ForEach(item =>
                    {
                        var Auther = objFacebookClient.Get("https://graph.facebook.com/" + item.ActionUserID.ToString());
                        if (Auther != null)
                        {
                            item.ActionUserName = ((JsonObject)Auther)["name"].ToString();
                        }
                        else
                        {
                            item.ActionUserName = null;
                        }
                    });
                }
                return objFacebookMessageList;
              
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
