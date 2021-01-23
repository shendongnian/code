    public class ModelView
    {
        public ModelView(int numberOfLeaves)
        {
            Cabbage = new Cabbage(){ Leaves = numberOfLeaves }
        }
        public Cabbage Cabbage { get; set; }
    }
