    public class Model
    {
        public Model()
        {
            SubModels = new List<SubModel>();
        }
        public IList<SubModel> SubModels { get; set; }
    }
    public class SubModel
    { 
        public int Id { get; set; }
        public string Name{ get; set; }
    }
