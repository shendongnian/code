                string test = "";
            var client = new FacebookClient();
            if (Request.Params["signed_request"] != null)
            {
                string payload = Request.Params["signed_request"].Split('.')[1];
                var encoding = new UTF8Encoding();
                var decodedJson = payload.Replace("=", string.Empty).Replace('-', '+').Replace('_', '/');
                var base64JsonArray = Convert.FromBase64String(decodedJson.PadRight(decodedJson.Length + (4 - decodedJson.Length % 4) % 4, '='));
                var json = encoding.GetString(base64JsonArray);
                var o = JObject.Parse(json);
                var lPid = Convert.ToString(o.SelectToken("page.id")).Replace("\"", "");
                var lLiked = Convert.ToString(o.SelectToken("page.liked")).Replace("\"", "");
                var lUserId = Convert.ToString(o.SelectToken("user_id")).Replace("\"", "");
                var lAdmin = Convert.ToString(o.SelectToken("admin")).Replace("\"", "");
                //test += lPid;    //current page id (where app is installed)
                //test += lLiked;  //page is liked by current visitor
                //test += lUserId; //current visitor
                //test += lAdmin;  //is current visitor an admin (does not work for me)
                if (lPid == "IDOFTHEPAGETOWORKWITH")
                {
                    //test += (lAdmin == "True" || lUserId == "ADMIN ID HERE") ? " is admin" : "not admin";
                    if (lLiked == "False")
                    {
                        test = "like it please";
                    }
                    else
                    {
                        test = "thank you";
                    }
                }
                
            }
            ViewBag.Test = test;
