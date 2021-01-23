    class PhysicMaterial
    {
       public virtual string GetCollisionSound (PhysicMaterialType targetType)
       {
           // define default behavior here, if derived class doesn't need to do anything special
       }
    }
    class AsteroidBall : PhysicMaterial
    {
       public override string GetCollisionSound (PhysicMaterialType targetType)
       {
           ...
       }
    }
    class BalloonRubber: PhysicMaterial
    {
       public override string GetCollisionSound (PhysicMaterialType targetType)
       {
           ...
       }
    }
