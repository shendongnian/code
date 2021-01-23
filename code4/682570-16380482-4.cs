    class SomethingThatCollides {
      public SomethingThatCollides(CollisionManager cm) {
        cm.CollisionEvent += CollisionWithObj;
      }
      void CollisionWithObj(object sender, CollisionEventArgs args) {
        if (args.Object is ObjectA) {
          CollisionWithObjA((ObjectA)args.Object);
        }
        else if (args.Object is ObjectB) {
          CollisionWithObjB((ObjectB)args.Object);
        }
      }
      // ...
    }
