    public class HomeController : AsyncController 
    {
        public void IndexAsync() 
        {
            AsyncManager.OutstandingOperations.Increment();
            sdk.Items().GetAll((items) => 
            {
                var price = items.Sum(i => i.Price); 
                AsyncManager.Parameters["price"] = price;
                AsyncManager.OutstandingOperations.Decrement();
            };
        }
    
        public ActionResult IndexCompleted(decimal price) 
        {
            ViewBag.price = price;
            return View();
        }
    }
