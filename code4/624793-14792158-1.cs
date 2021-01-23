    public class HomeController : AsyncController 
    {
        public void IndexAsync() 
        {
            AsyncManager.OutstandingOperations.Increment();
            sdk.Items().GetAll(items => 
            {
                decimal price = items.Sum(i => i.Price); 
                AsyncManager.Parameters["price"] = price;
                AsyncManager.OutstandingOperations.Decrement();
            };
        }
    
        public ActionResult IndexCompleted(decimal price) 
        {
            // Oh Dude, please use view models and crap on this ViewBag shit
            ViewBag.price = price;
            return View();
        }
    }
