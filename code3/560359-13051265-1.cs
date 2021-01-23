    static System.Web.Mvc.MvcHtmlString CheckFeedBack(string item) {
            String[] feedbacks = System.Text.RegularExpressions.Regex.Split(item, "of");
    
            //if feedback complete
            if((Convert.ToInt32(feedbacks[0]) == (Convert.ToInt32(feedbacks[1]))))
            {
                string newFeedback = @"<span class=""feedBackComplete"">"+ item +"</span>";
    
                return MvcHtmlString.Create(newFeedback);
            }
            return MvcHtmlString.Create(item);
        }
