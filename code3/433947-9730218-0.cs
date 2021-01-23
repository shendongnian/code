    public static class GlobalVariables
    {
       static GlobalVariables()
       {
           User = new User();
       }
       public static User User { get; set; }
    }
