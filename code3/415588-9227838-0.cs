    public void DoSomething<T>
    {
        if(typeof(T).IsEnum)
        {
           //Do Something
        } 
        else if (typeof(T).IsClass)
        {
           //Here you know T
           var bar = new Bar<T>();
           bar.GetData()
        }     
    }
    ....
    public class Bar<T>
    {
        public IProvideList<T> GetData<T>() where T : class
        {
            //Do Something
        }
    }
