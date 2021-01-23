    public delegate void DoStuffCallback(int num);
    
    public sealed class Test
    {
       public void ShowStuffOnOutput(int x, int y, DoStuffCallback callback)
       {
           Debug.WriteLine("pre-callback");
           Debug.WriteLine(x);
    
           Task.Run(() =>
           {
               callback(15);
           });
          
           Debug.WriteLine("post-callback");
           Debug.WriteLine(y);
       }
    }
