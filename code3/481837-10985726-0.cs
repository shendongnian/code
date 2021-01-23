    public partial class ReviewDetail
    {
        DBContext context = new DBContext();
    
        public void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                Session["Review"] = context.Reviews.FirstOrDefault(x => x.ReviewID = id);
            }
            else
            {
                Review review = Session["Review"] as Review;
                
    			Review reviewFromContext = context.Reviews.FirstOrDefault(x => x.ReviewID = review.ID);
            }
        }
    }
