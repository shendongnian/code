    public class MyFilter: ActionFilterAttribute {
    public override void OnActionExecuting(ActionExecutingContext filterContext) {
         // var user = _authService.GetUserAsync(username).Result;
         // Guarantees a new/different thread will be used to make the enclosed action
         // avoiding deadlocking the calling thread
         var user = Task.Factory.StartNew(
              () => _authService.GetUserAsync(username).Result,
              TaskCreationOptions.LongRunning).Result;
    }
}
