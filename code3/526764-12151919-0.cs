    public ActionResult Index()
    {
        ViewData["Message"] = "Welcome to ASP.NET MVC!";
        var Person = new Person
                         {
                             FirstName = "Ken",
                             LastName = "N",
                             Phones = new List<Phone>
                                          {
                                              new Phone {Ext = "O", PhoneNumber = "2341234"},
                                              new Phone {Ext = "O", PhoneNumber = "2341234"},
                                              new Phone {Ext = "O", PhoneNumber = "2341234"}
                                          }
                         };
        var serializedPersonObject = LosSerializeObject(Person);
        ViewData["PersonObject"] = serializedPersonObject;
        return View();
    }
    public ActionResult About()
    {
        var personString = Request.QueryString[0];
        var person = (Person) RetrieveObjectFromViewState(personString);
        return View();
    }
    string LosSerializeObject(object obj)
    {
        var los = new System.Web.UI.LosFormatter();
        var writer = new StringWriter();
        los.Serialize(writer, obj);
        return writer.ToString();
    }
    object RetrieveObjectFromViewState(string serializedObject)
    {
        var los = new System.Web.UI.LosFormatter();
        return los.Deserialize(serializedObject);
    }
