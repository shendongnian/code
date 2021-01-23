    public class Person
        {
            public string Name { get; set; }
            public string Surname { get; set; }
        }
    
    
    public class HomeController : Controller
        {
          
            public List<Person> personList = new List<Person>{ 
                                                            new Person{ Name="Jpnh", Surname="Coco"},
                                                            new Person{ Name="Mike", Surname="Nile"}  
                                                          };
    
            public ActionResult Index()
            {
                return View();
            }
    
            
    
            public ActionResult GetData()
            {
               
                return Json(personList);
            }
    
    }
    
     <script type="text/javascript" language="javascript">
    
            $(document).ready(function () {
    
                $('#button').click(GetValue);
    
            });
    
            function GetValue() {
                $.ajax({
                    url: "/Home/GetData",
                    success: function (data) {
                        alert(data[0].Name);
                    }
    
                });
    
            };
    
        </script>
