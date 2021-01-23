    // StackOverflow 16764155
    public class Series
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class State
    {
        public State()
        {
            Serieses = new List<Series>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Series> Serieses { get; set; }
    }
    public class DbForm
    {
        public IEnumerable<Series> Selection { get; }
    }
    public class DbLogic
    {
        public void Create(State state, IEnumerable<Series> selection)
        {
            state.Serieses.AddRange(selection);
            // do db stuff
            // _db.Entry(state).State = EntityState.Modified;
            // _db.SaveChanges();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var form = new DbForm();
            var state = new State();
            var db = new DbLogic();
            // stuff here
            var sel = form.Selection;
            db.Create(state, sel);
        }
    }
