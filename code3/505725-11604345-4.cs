    public partial class UserControl1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public event EventHandler<MyCustomeEventArgs> MyCustomClickEvent;
        protected virtual void OnMyCustomClickEvent(MyCustomeEventArgs e)
        {
            if (MyCustomClickEvent != null)
                MyCustomClickEvent(this, e);
        }
        public void button1_Click(object sender, EventArgs e)
        {
            OnMyCustomClickEvent(new MyCustomeEventArgs(5));
        }
    }
    public class MyCustomeEventArgs : EventArgs
    {
        public MyCustomeEventArgs(int searchID)
        {
            SearchID = searchID;
        }
        public int SearchID { get; set; }
    }
