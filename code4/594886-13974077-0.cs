    public delegate void MyClassEHandler(MyClassEParam param);  
    static MyClassEHandler error;
    public static event MyClassEHandler Error
    {
     add
     {
          MyClassE.error += (MyClassEHandler)Delegate.Combine(MyClassE.Error, value);
     } 
     remove
     {
          MyClassE.Error -= (MyClassEHandler)Delegate.Combine(MyClassE.Error, value);
     } 
    }
