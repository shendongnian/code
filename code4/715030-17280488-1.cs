    public interface ITagModel { }
    
    public interface ITemplate<TModel>
        where TModel : ITagModel
    {
        TModel Model { get; set; }
    }
    
    public class EmailTag : ITagModel { }
    
    public class EmailTest : ITemplate<EmailTag> {
        public EmailTag Model { get; set; }
    }
