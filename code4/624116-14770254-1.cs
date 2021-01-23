    public MyClass
    {
         public static event EventHandler<MyArgs> NotifyParentUI;
    
         protected virtual void OnMyEvent(MyArgs ea)
         {
             if (NotifyParentUI != null)
             {
                 NotifyParentUI(this, ea);
             }
         }
    }
