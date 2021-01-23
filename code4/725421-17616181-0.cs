    public interface ICanBeSoftDeleted
    {
        bool IsDeleted { get; }
    }
    public abstract class CanBeSoftDeleted : ICanBeSoftDeleted
    {
        private bool _IsDeleted;
        public bool IsDeleted
        {
            get { return _IsDeleted; }
        }
        internal void SetIsDeleted(bool value) { _IsDeleted = value; }
    }
