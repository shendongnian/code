    public static class UserExtensions
    {
     public static List<REPORT> ReportsWithSomeCondition(this USER user)
     {
        return user.REPORTs.Where(...).ToList();
     }
    }
