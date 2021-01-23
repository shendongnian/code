    public partial class _Default : BasePage {
        protected void Page_Load(object sender, EventArgs e) {
            Person p = new Person {
                FirstName = "MyFName",
                LastName = "MyLName"
            };
            SetSessionData<Person>("somevalue", p);
            var person = GetSessionData<Person>("somevalue");
        }
    }
    public class BasePage : System.Web.UI.Page {
        internal void SetSessionData<T>(string name, T value) {
            this.Session[string.Format("{0}_{1}", value.GetType().GUID, name)] = value;
        }
        internal T GetSessionData<T>(string name) {
            return (T)this.Session[string.Format("{0}_{1}", typeof(T).GUID, name)];
        }
    }
    public class Person {
        public Person() {
            ID = Guid.NewGuid();
        }
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
