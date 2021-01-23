    public static void Show(string Message, string redirect) 
    {
       // ...
       messageQueue.Enqueue(Message);
       handlerPages.Add(HttpContext.Current.Handler, messageQueue);
       contexts.Add(HttpContext.Current.Handler, redirect); // add this line
       currentPage.Unload += new EventHandler(CurrentPageUnload);
       // ...
    }
