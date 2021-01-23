    [HttpGet]
            public ActionResult Index()
            {
                RecipeModel rec = new RecipeModel();    
                return View( rec.GetAllRecipes(););
            }
