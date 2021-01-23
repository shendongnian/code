    public class AchievementA : AchievementBase
    {
      public void GetAchievementForAByUser(int userId)
      {
           base.CheckId(userId);
      }
     }
    public class AchievementB : AchievementBase
     {
      }
     public class AchievementManager : IAchievement
    {
        protected void CheckId(int userId)
    {
    }
