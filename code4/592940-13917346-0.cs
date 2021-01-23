    static class Super
    {
        static void M1()
        {
        }
        static void M2()
        {
        }
        static List<Action> Actions = new List<Action>(); 
        static Super()
        {
            Actions.Add(M1);
            Actions.Add(M2); 
        }
        static void CallSupper(int nr)
        {
            try
            {
                Actions[nr - 1](); 
            }
            catch (Exception ex)
            {
    
            }
        }
    }
