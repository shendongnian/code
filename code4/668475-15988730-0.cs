    public class MyViewModel
    {
        public MyViewModel()
        {
            this.Files = FilesManager.Instance().GetFiles();
        }
        public XXX Files { get; private set; }
    }
    <ListBox ItemsSource="{Binding Files}" ... />
