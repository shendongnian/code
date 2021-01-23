    public class SoleModel
    {
        private readonly string _code;
        private readonly string _name;
        private readonly int _id;
    
        public SoleModel(string code, string name, int id)
        {
            _code = code;
            _name = name;
            _id = id;
        }
    
        public string Code { get { return _code; } }
        public string Name { get { return _name; } }
        public int Id { get { return _id; } }
    }
    SoleColorService.All()
                    .GroupBy(t => t.Sole.Code)
                    .Select(g => g.First())
                    .Select(x => new SoleModel(x.Sole.Code, x.Sole.Name x.SoleID)); 
