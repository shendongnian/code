    public abstract class BaseAttachment
    {
        public abstract string GetName();
    }
    public abstract class BaseFileAttachment : BaseAttachment
    {
    }
    public class ExchangeFileAttachment : BaseFileAttachment
    {
        string name;
        public override string GetName()
        {
            return name;
        }
    }
