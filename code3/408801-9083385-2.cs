    Static Dashboard thisPage;
    protected void Page_Load(object sender, EventArgs e)
    {
       …
       thisref = this;
       …
    }
    
    [WebMethod]
    [ScriptMethod]
    public static void SaveModalExamDateChangesToDB(string days, string date)
    {
       thisPage.UserSession.UserCourse.ExamDate = DateTime.Parse(date);
       thisPage.UserSession.UserCourse.StudyDays = days;
       thisPage.UserSession.UserCourse.Save();
    }
 
