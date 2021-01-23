    public static void Show(string Message, string redirect) 
    {
       // ...
       messageQueue.Enqueue(Message);
       handlerPages.Add(HttpContext.Current.Handler, messageQueue); // add this line
       contexts.Add(HttpContext.Current.Handler, redirect);
       currentPage.Unload += new EventHandler(CurrentPageUnload);
       // ...
    }
