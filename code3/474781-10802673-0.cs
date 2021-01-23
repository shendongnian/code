    public abstract class BaseClass
    { 
      public abstract BaseClassSettings Write(); 
    } 
 
    public abstract class BaseClassSettings
    {
      public abstract BaseClass CreateCorrespondingInstance();
    } 
