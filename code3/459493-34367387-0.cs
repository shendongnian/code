    In controllers action add:
     public ActionResult Index()
            {
                try
                {
                    int a, b, c;
                    a = 2; b = 2;
                    c = a / b;
                    ViewBag.ShowMessage = false;
                }
                catch (Exception e)
                {
                    ViewBag.ShowMessage = true;
                    ViewBag.data = e.Message.ToString();
                }
                return View();    // return View();
    
            }
    
    in Index.cshtml
    Place at the bottom:
    
    <input type="hidden" value="@ViewBag.data" id="hdnFlag" />
    
    @if (ViewBag.ShowMessage)
    {
        <script type="text/javascript">
           
            var h1 = document.getElementById('hdnFlag');
    
            alert(h1.value);
          
        </script>
        <div class="message-box">Some Message here</div>
    }
