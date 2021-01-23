    public class UserPanelController : Controller
    {
        Customer cu;
        Customer.customer cust;
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (Login.ChekLogin())
            {
                cust = cu.Read(int.Parse(Session["username"].ToString()));
                // error Occur here Session is null
            }
        }
    }
