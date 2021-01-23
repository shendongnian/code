    public class Person : IEntity{ 
     public virtual string Name{..}
     public virtual string Lastname{..}
     
     [NoProperty]
     public virtual string FullName{ // Not created property
      get { return Name +  " " + Lastname;  }
     }
    }
    public class Group : IEntity{ 
     public virtual string FullName{..} //Created property
    }
