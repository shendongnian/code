    public class Person : EntityBase
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { ChangeAndNofity(ref _id, value, () => Id); }
        }
    }
