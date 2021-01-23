    Ultoo u = new Ultoo();
    u.UserName = Request["username"].ToString();
    u.Password = Request["password"].ToString();
    QuestionGenerator.Initialize(); // from the main thread
    new Thread(u.CompletePoll).Start();
    public static class QuestionGenerator
    {
        public static void Initialize()
        {
            var firstParts = FirstParts;
            var secondParts = SecondParts;
            // merely reading the properties is enough to initialise them, so ignore the results
        }
    }
