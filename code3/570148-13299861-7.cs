    public interface IResultFilter
    {
        // Summary:
        //     Called after an action result executes.
        //
        void OnResultExecuted(ResultExecutedContext filterContext);
        //
        // Summary:
        //     Called before an action result executes.
        //
        void OnResultExecuting(ResultExecutingContext filterContext);
    }
