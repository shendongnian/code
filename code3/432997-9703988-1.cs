    public abstract class PresenterBase<TItem>
    {
       public TItem Current { get; private set; }
    }
    // now Current will be of PersonApplication type
    public sealed class ApplicationPresenter : PresenterBase<PersonApplication>
    {
    }
    // now Current will be of PersonRecord type
    public sealed class RecordPresenter : PresenterBase<PersonRecord>
    {
    }
