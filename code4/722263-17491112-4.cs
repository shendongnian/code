    public static BaseType Choose(int x, string name) 
    {
        if (x == 1)
        {
           Articles art = new Articles(name);
           return art;
        }
        if (x == 2)
        {
            Questionnaire ques = new Questionnaire(name);
            return ques;
        }
    }
