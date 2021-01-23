    public class MyClass
    {
        public void MyMethod<T>(EventHandler handler)
        {
            var methodInfo = handler.GetMethodInfo();
            var @delegate = methodInfo.CreateDelegate(typeof(OpenEventHandler<T>), null);
        }
    }
    public delegate void OpenEventHandler<in T>(T target, object sender, EventArgs arguments);
