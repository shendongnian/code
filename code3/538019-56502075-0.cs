    public class MyClass
    {
        public MyClass(RaisesEvent otherClass)
        {
            otherClass.MyEvent += MyAction;
        }
    
        private Action MyAction => async () => await ThingThatReturnsATask();
        
        public void Dispose() //it doesn't have to be IDisposable, but you should unsub at some point
        {
            otherClass.MyEvent -= MyAction;
        }
        
        private async Task ThingThatReturnsATask()
        {
            //async-await stuff in here
        }
    }
