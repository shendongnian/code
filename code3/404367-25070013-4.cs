    public class GameObjectPool : Pool<GameObject>
    {   
       public GameObjectPool(int initialCapacity)
          :base(initialCapacity, CreateObject, ResetObject)
       {
       }
       
       private GameObject CreateObject()
       { ... }
    
       private GameObject ResetObject()
       { ... }
    }
