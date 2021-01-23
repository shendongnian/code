        public ActionResult Create()
            {
                    var vm = new StudentBookCityViewModel();
                    using(var ctx = EFDbContext(connectionString))
                    {
                    var student = ctx.Students.First();
                    vm.StudentName=student.Name;
        vm.Books = student.Books.ToList(); //make sure to call ToList() to load values from db
        ...
                    }
                    return View(vm);
                }
            [HttpPost]
        public ActionResult Create(StudentBookCityViewModel model)
        {
    
            //I don't understand how I can save values to db
    
            //here you have the model with all infomation from the form
           foreach(var book in model.Books){
            context.Books.First(b=>b.BookId == book.BookId).IsSelected = book.IsSelected;
    }
            context.SaveChanges();
    
            return RedirectToAction("Index");
        }
