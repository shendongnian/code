    public class SubCategoryViewModel
    {
       public int Id {get;set;}
       public int RootCategoryId {get;set;}
       [Required]
       public string Name { get; set; }
    }
    [Authorize]
    public ActionResult Create()
    {
       var subCategoryViewModel = new SubCategoryViewModel();
       return View(subCategoryViewModel);
    }
    [Authorize]
    [HttpPost]
    public ActionResult Create(SubCategoryViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
           var subCategory = new SubCategory();
           subCategory.RootCategoryID = 1;
           subCategory.CategoryName = viewModel.Name;
           //And some BL logic called here to handle new object...
           
        }
    }
