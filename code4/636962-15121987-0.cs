    public partial class _Default : System.Web.UI.Page
    {
        GLM.NumBox NumBox1;
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
        protected void Button_SquareIt_Click(object sender, EventArgs e)
        {
           NumBox1.Num = NumBox1.Num *  NumBox1.Num;
        }
    }
