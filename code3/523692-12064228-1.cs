    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Person> tmp = new List<Person>();
            tmp.Add(new Person() { LastName = "Escano", Name = "Hanlet" });
            tmp.Add(new Person() { LastName = "Escano", Name = "Hanlet" });
            tmp.Add(new Person() { LastName = "Escano", Name = "Hanlet" });
            tmp.Add(new Person() { LastName = "Escano", Name = "Hanlet" });
            tmp.Add(new Person() { LastName = "Escano", Name = "Hanlet" });
            this.repPeople.DataSource = tmp;
            this.repPeople.DataBind();
        }
        public void text_databinding(object sender, EventArgs e)
        { 
            Response.Write(((TextBox)sender).ClientID + "<br />") ;
        }
    }
    
    public class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }
