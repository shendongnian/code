    namespace Bridge
    {
        public class Startup
        {
            public async Task<object> Invoke(Func<object, Task<object>>callback)
            {
                Bridge.Base.setCallback(callback);
                MainForm mainForm = new Bridge.MainForm();
                Task.Run(async () =>
                {
                    Application.Run(mainForm);
                });
                return (Func<object, Task<object>>)(async (i) => { Bridge.Base.release(); return null; });
            }
        }
    }
    // inside Bridge.Base
    static public void setCallback(Func<object, Task<object>> cb)
    {
        if (callback == null)
        {
            callback = cb;
        }
    }
    static public async void Emit(string name, object data)
    {
        return await Task.Run(async () =>
        {
            return await callback(new {
                name = name,
                data = data
            });
        });
    }
    static public Func<object, Task<object>> callback = null;
