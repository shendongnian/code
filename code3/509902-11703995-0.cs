    using System.Threading;
    Thread t = new Thread(()=>{
    while(true)
    {
    //call your method here...
    Thread.Sleep(500); //optional if you want a pause between calls.
    }
    });
    t.IsBackground = true;
    t.Start();
