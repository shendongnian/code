    static System.Web.Mvc.MvcHtmlString CheckFeedBack(string item) {
            String[] feedbacks = System.Text.RegularExpressions.Regex.Split(item, "of");
    
            //if feedback complete
            if((Convert.ToInt32(feedbacks[0]) == (Convert.ToInt32(feedbacks[1]))))
            {
                string newFeedback = @"<span class=""feedBackComplete"">"+ item +"</span>";
                string encodedFeedback = System.Web.HttpUtility.HtmlEncode(newFeedback);
    
                return MvcHtmlString.Create(encodedFeedback);
            }
            return MvcHtmlString.Create(item);
        }
