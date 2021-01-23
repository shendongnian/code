    public class Foo
    {
        public event Action MyEvent;
        public async Task FireEvent()
        {
            Action myevent = MyEvent;
            if (MyEvent != null)
            {
                await Task.Run(() => myevent());
                //TODO code to run in UI thread after event runs goes here
            }
        }
    }
