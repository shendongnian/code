    public class MyBaseActivity<TViewModel>
        : MvxBindingActivityView<MvxNullViewModel>
    {
        public new TViewModel ViewModel { get; set; }
        public override object DefaultBindingSource
        {
            get { return ViewModel; }
        }
        protected sealed override void OnViewModelSet()
        {
            // ignored  here
        }
    }
