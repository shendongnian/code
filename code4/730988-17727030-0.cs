    class BaseClass
    {
      public virtual void Save()
      {
        //Use this keyword
      }
    }
    class B : BaseClass
    {
      public override void Save()
      {
        base.Save();
      } 
    }
