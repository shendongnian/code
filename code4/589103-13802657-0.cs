    using System.Diagnostic
    using System.Window.Forms
    
    //your code
    Stopwatch watch = new Stopwatch();
    watch.Start();
     
    // start reading lines of a file using file system object
    
    watch.Stop();
    
    if(watch.Elapsed.ElapsedMilliseconds>5000)
    {
       MessageBox.Show("The process takes more than 5 seconds !!!");
    }
    else
    {
       // your business logic
    }
