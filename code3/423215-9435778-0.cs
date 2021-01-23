    string[] files = System.IO.Directory.GetFiles(@"C:\Users\Public\Pictures\Sample Pictures", "*.jpg");
    string newDir = @"C:\Users\Public\Pictures\Sample Pictures\Modified";
    System.IO.Directory.CreateDirectory(newDir);
    
    //  Method signature: Parallel.ForEach(IEnumerable<TSource> source, Action<TSource> body)
    Parallel.ForEach(files, currentFile =>
    {
        // The more computational work you do here, the greater 
        // the speedup compared to a sequential foreach loop.
        string filename = System.IO.Path.GetFileName(currentFile);
        System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(currentFile);
    
        bitmap.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);
        bitmap.Save(System.IO.Path.Combine(newDir, filename));
    
        // Peek behind the scenes to see how work is parallelized.
        // But be aware: Thread contention for the Console slows down parallel loops!!!
        Console.WriteLine("Processing {0} on thread {1}", filename,
        Thread.CurrentThread.ManagedThreadId);
    
        } //close lambda expression
    ); //close method invocation
