    public class FruitViewModel
    {
        public bool Apple { get; set; }
        public bool Orange { get; set; }
        public bool Banana { get; set; } 
    }
    
    public ActionResult ListFruits() 
    {
       var model = new FruitViewModel();
       return View("Fruits", model);
    }
