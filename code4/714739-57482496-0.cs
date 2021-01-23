public class StandardController : Controller
{
    public ActionResult Save()
    {
        //code...
        YourMethod();
        //code...
        return View();
    }
    public async void YourMethod()
    {
      await Task.Run(()=>{
      //your async code...
      });
    }
}
YourMethod() will be going before and after Save() is fully performed.
