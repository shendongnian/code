    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<ClassB> myobject = new List<ClassB>();
            myobject.Add(new ClassB() { X = "1", Y = "2" });
            myobject.Add(new ClassB() { X = "3", Y = "4" });
            myddl.DataSource = myobject;
            myddl.DataTextField = "X";
            myddl.DataValueField = "Y";
            myddl.DataBind();
        }
    }
    public class ClassB : ClassA
    {
    }
    public class ClassA
    {
        public string X { get; set; }
        public string Y { get; set; }
    }
