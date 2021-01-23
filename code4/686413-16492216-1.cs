    public class News
        {
            public int id { get; set; }
            public string title { get; set; }
            public string content { get; set; }
            //as many properties as you want
        }
        public partial class bindGridviewToList : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                News n1 = new News() { id = 1, content = "content", title = "title" };
                News n2 = new News() { id = 2, content = "content", title = "title" };
                News n3 = new News() { id = 3, content = "content", title = "title" };
    
                List<News> newsList = new List<News>();
    
                newsList.Add(n1); newsList.Add(n2); newsList.Add(n3);
    
                GridView1.DataSource = newsList;
                GridView1.DataBind();
            }
        }
