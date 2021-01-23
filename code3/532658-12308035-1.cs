    public partial class _Default : System.Web.UI.Page
        {
            public class myObject
            {
                public string FileName { get; set; }
                public int myId { get; set; }
            }
            protected void Page_Load(object sender, EventArgs e)
            {
                List<myObject> myList = new List<myObject>();
                myList.Add(new myObject {myId = 1, FileName = "one" });
                myList.Add(new myObject { myId = 2, FileName = "two" });
                myList.Add(new myObject { myId = 3, FileName = "three" });
    
                Repeater1.DataSource = myList;
                Repeater1.DataBind();
            }
    
            protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
            {
                Label item = (Label)e.Item.FindControl("label1");
    
            }
        }
