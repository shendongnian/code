    public partial class ReservationProduct : System.Web.UI.Page
    {
        // ...
        protected void Page_Load(object sender, EventArgs e)
        {
            buyTourProduct.MyHideEvent += new BuyTourProduct.MyHideEventDelegate(buyTourProduct_MyHideEvent);
        }
        // ...
        void buyTourProduct_MyHideEvent()
        {
            tourProductDetail.SetPanelNameVisible(false);
        }
        // ...
    }
