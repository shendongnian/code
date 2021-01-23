    public abstract class BaseClass
    {
        protected virtual int UserId { get; set; }
    }
    public class ChildClass : BaseClass
    {
        private int _userId;
        protected override int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
    }
