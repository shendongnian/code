    public abstract class BasePrsenter<TItem>
    {
       public TItem Current { get; private set; }
    }
    // now Current will be of PersonApplication type
    public sealed class ApplicationPresenter : BasePresenter<PersonApplication>
    {
    }
    // now Current will be of PersonRecord type
    public sealed class RecordPresenter : BasePresenter<PersonRecord>
    {
    }
