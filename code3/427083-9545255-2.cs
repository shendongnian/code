    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new MyViewModel());
        }
        [HttpPost]
        public ActionResult Index(MyViewModel model)
        {
            if (model.File != null && model.File.ContentLength > 0)
            {
                var imageFolder = Server.MapPath("~/image");
                var ext = Path.GetExtension(model.File.FileName);
                var file = Path.ChangeExtension(Guid.NewGuid().ToString(), ext);
                var fullPath = Path.Combine(imageFolder, file);
                model.File.SaveAs(fullPath);
                // Save the full path of the uploaded file
                // in the database. Obviously this code should be externalized
                // into a repository but for the purposes of this example
                // I have left it in the controller
                var connString = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
                using (var conn = new SqlConnection(connString))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "INSERT INTO images VALUES (@path)";
                    cmd.Parameters.AddWithValue("@path", fullPath);
                    cmd.ExecuteNonQuery();
                }
            }
            return View(model);
        }
    }
