    [WebMethod]
        public static string getQuestions(){
    
            var userGuid = (Guid)System.Web.Security.Membership.GetUser().ProviderUserKey;
            IEnumerable<Question> list = Question.getQuestionsForUser(userGuid).Select(x => new Question
            {
                Uid = x.Uid,
                Content = x.Content
            });
    
            return new JavaScriptSerializer().Serialize(list);
        }
