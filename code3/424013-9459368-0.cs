    public class ShowWithTv {
        public Show { get; set; }
        public TV { get; set; }
    }
    
    public ActionResult Index(int ID) {
    	var data = new ShowWithTV();
    	data.Show = new Show();
    	data.TV = new TV().LoadFromId(ID) // put code here to load TV from ID
    	return View(data);
    }
