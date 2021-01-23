    [HttpPost]
    public ActionResult Message_Send_Get(MessageModel message_to_send)
    {
        if (ModelState.IsValid)
        {
            WebRequest wrGETURL;
            //This is a string that points to the location of the Web Service 
            string web_service_location = "http://www.google.com?";
            //This initates a new writeable instance of HttpValueCollection
            NameValueCollection query_string = System.Web.HttpUtility.ParseQueryString(string.Empty);
            //This builds up the query string that will be used for the redirect
            query_string["code"] = message_to_send.code;
            query_string["password"] = message_to_send.password;
            query_string["from"] = message_to_send.sms_from;
            // Warning: you seem to have used some Message_List argument in your action
            // but there's no corresponding input field in the view or in the model
            // maybe you want to add some
            // query_string["msg"] = message_to_send.sms_from.msg;
            //This concatinates the web_service_location (String) and query_string (String)
            send_url = web_service_location + query_string.ToString();
            Debug.WriteLine(send_url);
            // Warning: Here you only created the request but never sent it
            // I guess you will have to complete the code .....
            wrGETURL = WebRequest.Create(send_url);
        }
        // since we want to redisplay the same view we need to reassign the
        // MessagesList property used by the dropdown because in HTML a dropdown
        // sends only the selected value when the form is submitted and not the entire
        // list of options
        message_to_send.MessagesList = smse.Messages
           .Select(c => new SelectListItem
           {
               Value = c.message1,
               Text = c.message1
           });
        return View(message_to_send);
    }
