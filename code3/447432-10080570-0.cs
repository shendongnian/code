    public interface IDatabaseSaveable
    {
       void InsertToDatabase(Database pDatabase);
       void UpdateDatabase(Database pDatabase);
    }
    public class Potato : IDatabaseSaveable
    {
       private int mID;
       private double mSmoothness;
       public void InsertToDatabase(Database pDatabase)
       {
          pDatabase.InsertToPotatoes(mID, mSmoothness, ...);
       }
       public void UpdateDatabase(Database pDatabase)
       {
          pDatabase.UpdatePotatoes(mID, mSmoothness, ...);
       }
    }
