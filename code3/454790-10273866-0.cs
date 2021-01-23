    public abstract class Enemy
    {
       private readonly int mEnemyData;
       protected Enemy(Enemy pEnemy)
       {
          mEnemyData = pEnemy.mEnemyData;
       }
       public abstract Enemy Clone();
    }
    public sealed class GenericEnemy : Enemy
    {
       private readonly double mGenericEnemyData;
       private GenericEnemy(GenericEnemy pGenericEnemy)
        : base(pGenericEnemy)
       {
          mGenericEnemyData = pGenericEnemy.mGenericEnemyData;
       }
       public override Enemy Clone()
       {
          return new GenericEnemy(this);
       }
    }
