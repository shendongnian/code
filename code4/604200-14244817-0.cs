    var AnimalList = new List<SelectListItem>();
    AnimalList.Add(new SelectListItem { Text = "Dog", Value = "1" });
    AnimalList.Add(new SelectListItem { Text = "Cat", Value = "2" });
    AnimalList.Add(new SelectListItem { Text = "Mouse", Value = "3" });
    this.ViewBag.Animals = new SelectList(AnimalList, "Value", "Text", "3");
