    // Use the "ClipboardManager" to manage in a more comprehensive the clipboard
    // I assume that "this" is a Form
    ClipboardManager manager = new ClipboardManager(this);
    // Use "All" to handle all kinds of objects from the clipboard
    // otherwise use "Files", "Image" or "Text"
    manager.Type = ClipboardManager.CheckType.All;
    // Use events to manage the objects in the clipboard
    manager.OnNewFilesFound += (sender, eventArg) => 
    {
        foreach (String item in eventArg)
        {
            Console.WriteLine("New file found in clipboard : {0}", item);
        }
    };
    manager.OnNewImageFound += (sender, eventArg) =>
    {
        Console.WriteLine("New image found in clipboard -> Width: {0} , Height: {1}", 
                          eventArg.Width, eventArg.Height);
    };
    manager.OnNewTextFound += (sender, eventArg) =>
    {
        Console.WriteLine("New text found in clipboard : {0}", eventArg);
    };
    // Use the method "StartChecking" to start capturing objects in the clipboard
    manager.StartChecking();
    // Close the capturing
    manager.Dispose();
