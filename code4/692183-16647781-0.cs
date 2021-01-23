    public class CartController : Controller
    {
       public ActionResult Index()
       {
          return View();
       }
    
       public ActionResult Pay()
       {
          PayPalRedirect redirect = PayPal.ExpressCheckout(new PayPalOrder { Amount = 50 });
    
          Session["token"] = redirect.Token;
    
          return new RedirectResult(redirect.Url);
       }
    }
