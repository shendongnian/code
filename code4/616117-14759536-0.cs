    // Abstract View
    public interface IView<TItem, TKey>
    {
        void Fill(TItem[] items);
        event SelectEvent<TKey> SelectionChanged;
        event MessageEvent Add;
    }
    // Event Delegates
    public delegate void SelectEvent<TKey>(TKey selectedValue);
    public delegate bool MessageEvent();
    // Model Entities
    public class Note { }
    public class Attachment { }
    // Abstract Presenter
    public abstract class Presenter<TItem, TKey>
    {
        protected TKey SelectedValue { get; private set; }
        protected IView<TItem, TKey> View { get; set; }
        public Presenter(IView<TItem, TKey> view)
        {
            View = (IView<TItem, TKey>)view;
            View.SelectionChanged += OnSelectionChangedInternal;
            View.Add += OnAdd;
        }
        void OnSelectionChangedInternal(TKey selectedValue)
        {
            this.SelectedValue = selectedValue;
            OnSelectionChanged(selectedValue);
        }
        protected abstract void OnSelectionChanged(TKey selectedVaule);
        protected abstract bool OnAdd();
    }
    // Concrete Views
    public interface INotes : IView<Note, string> { }
    public interface IAttachments : IView<Attachment, string> { }
    // Concrete Presenters
    public class NotesPresenter : Presenter<Note, string>
    {
        public NotesPresenter(INotes view) : base(view) { }
        protected override void OnSelectionChanged(string publisherName) { }
        protected override bool OnAdd() { return false; }
    }
    public class AttachmentsPresenter : Presenter<Attachment, string>
    {
        public AttachmentsPresenter(IAttachments view) : base(view) { }
        protected override void OnSelectionChanged(string publisherName) { }
        protected override bool OnAdd() { return false; }
    }
