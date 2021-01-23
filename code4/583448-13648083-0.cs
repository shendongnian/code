    public MyController : Controller
    {
      public async Task<ActionResult> DoSomething()
      {
        await Task.Run(() => CallSomeMethodWhichDoesAsyncOperations());
        return Json(new { success = successful }, JsonRequestBehavior.AllowGet);
      }
    }
