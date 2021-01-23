    public delegate void MyClassEHandler(MyClassEParam param);
    
    public static event MyClassEHandler Error
    {
         add
         {
              MyClassE.Error += value;
         } 
    }
