    public class HttpContextDisposableLifetimeManager : LifetimeManager, IDisposable
    {        
        const string _itemName = typeof(T).AssemblyQualifiedName;
    
        public void DisposingHandler(object source, EventArgs e)
        {
            RemoveValue();
        }
    
        public override object GetValue()
        {
            return HttpContext.Current.Items[_itemName];
        }
        public override void RemoveValue()
        {
            Dispose();
            HttpContext.Current.Items.Remove(_itemName);
        }
    
        public override void SetValue(object newValue)
        {
            HttpContext.Current.Items[_itemName] = newValue;
        }
        public void Dispose()
        {
            var obj = (IDisposable)GetValue();
            obj.Dispose();
        }
    }
