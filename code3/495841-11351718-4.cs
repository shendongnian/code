    public sealed class One : BaseViewModel
    {
        // init collection in ctor as not using EF in test
        // no requirement in real app
        public One()
        {
            Two = new Collection<Two>();
        }
        public int OneId { get; set; }
        public ICollection<Two> Two { get; set; }
    }
    public class Two
    {
        public int TwoId { get; set; }
        public int OneId { get; set; }
        [ScriptIgnore]
        public virtual One One { get; set; }
    }
    public abstract class BaseViewModel
    {
        public string AsJson()
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Serialize(this);
        }
    }
    public class OnePoco  : BaseViewModel
    {
        public int OneId { get; set; }
        public virtual ICollection<TwoPoco> Two { get; set; }
    }
    public class TwoPoco
    {
        public int TwoId { get; set; }
        public int OneId { get; set; }
    }
