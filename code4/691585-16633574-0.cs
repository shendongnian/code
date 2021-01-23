    interface IPlugin {
       PluginResult ReadAndExecuteEvents(Events e);
       // Added asynchronous methods.
       IAsyncResult BeginReadAndExecuteEvents(Events e, AsyncCallback cb, Object state);
       PluginResult EndReadAndExecuteEvents(IAsyncResult result);
    }
