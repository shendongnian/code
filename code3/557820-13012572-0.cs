    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var colours = new List<CarColour>() { new CarColour() { Id = Guid.NewGuid(), Colour = "Red" }, new CarColour() { Id = Guid.NewGuid(), Colour = "Blue" }, new CarColour() { Id = Guid.NewGuid(), Colour = "Green" } };
            ViewData["Colours"] = new SelectList(colours, "Id", "Colour");
    
            var car = new Car() { Id = Guid.NewGuid(), Name = "GreenCar", Colour = colours.First(cc => cc.Colour == "Green") };
            return View(car);
        }
    }
    
    public class Car
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public CarColour Colour { get; set; }
    }
    
    public class CarColour
    {
        public Guid Id { get; set; }
        public string Colour { get; set; }
    }
