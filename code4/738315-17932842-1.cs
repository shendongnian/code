    [Activity(Label = "View for FirstViewModel")]
    public class FirstView : MvxActivity
    {
        public new FirstViewModel ViewModel
        {
            get { return (FirstViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);
            var button = FindViewById<Button>(Resource.Id.button);
            button.Click += (sender, args) => ViewModel.IsPressed = !ViewModel.IsPressed;
        }
    }
