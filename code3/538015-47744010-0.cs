    public static class FileProcessEventHandlerExtensions
    {
        public static Task InvokeAsync(this FileProcessEventHandler handler, object sender, FileProcessStatusEventArgs args)
         => Task.WhenAll(handler.GetInvocationList()
                                .Cast<FileProcessEventHandler>()
                                .Select(h => h(sender, args))
                                .ToArray());
    }
