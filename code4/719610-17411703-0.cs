    [HttpPost]
    public ActionResult Index(ViewModelData vm)
    {
        foreach (var book in vm.Books) {
            context.Books.First(x => x.BookId == book.BookId).IsSelected = book.IsSelected;
        }        
        
        var student = context.Students.First();
        student.Name = vm.StudentName;//now I've actually changed the student entity and changes will be pushed to database on Save()
        context.SaveChanges();
        return View(vm);
    }
