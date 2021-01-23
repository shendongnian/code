    public class Bindable<T>: RealProxy, INotifyPropertyChanged
    {
        private T obj; 
    
        private Bindable(T obj)
            : base(typeof(T))
        {
            this.obj = obj;
        }
        
        // not sure if this compiles, 
        // make it a property in that case and the ctor public 
        public static T BuildProxy(T obj) 
        {
           return (T) new Bindable<T>(obj).GetTransparentProxy();
        }
        public override IMessage Invoke(IMessage msg)
        {
            var meth = msg.Properties["__MethodName"].ToString();
            var bf = BindingFlags.Public | BindingFlags.Instance ;
            if (meth.StartsWith("set_"))
            {
                meth = meth.Substring(4);
                bf |= BindingFlags.SetProperty;
            }
            if (meth.StartsWith("get_"))
            {
               bf |= BindingFlags.GetProperty;
               // get the value...
                meth = meth.Substring(4);
            }
            var args = new object[0];
            if (msg.Properties["__Args"] != null)
            {
                args = (object[]) msg.Properties["__Args"];
            }
            var res = typeof (T).InvokeMember(meth, 
                bf
                , null, obj, args);
            if ((bf && BindingFlags.SetProperty) ==  BindingFlags.SetProperty)
            {
                OnPropertyChanged(meth);   
            }
            return new ReturnMessage(res, null, 0, null, null);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
           if (PropertyChanged != null)
           {
               PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
           }
        } 
    }
