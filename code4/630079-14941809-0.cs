        public ActionResult Index()
        {
           ViewData["listColors"] = colors;
            ViewData["dateNow"] = DateTime.Now;
            ViewData["name"] = "Hajan";
            ViewData["age"] = 25;;
        
            ViewBag.ListColors = colors; //colors is List
            ViewBag.DateNow = DateTime.Now;
            ViewBag.Name = "Hajan";
            ViewBag.Age = 25;
            return View(); 
        }
    <p>
        My name is 
        <b><%: ViewData["name"] %></b>, 
        <b><%: ViewData["age"] %></b> years old.
        <br />    
        I like the following colors:
    </p>
    <ul id="colors">
    <% foreach (var color in ViewData["listColors"] as List<string>){ %>
        <li>
            <font color="<%: color %>"><%: color %></font>
        </li>
    <% } %>
    </ul>
    <p>
        <%: ViewData["dateNow"] %>
    </p>
