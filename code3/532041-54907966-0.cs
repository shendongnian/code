    public class FolderBrowserDialogBehavior : Behavior<System.Windows.Controls.Button>
    {
        /// <summary>
        /// Dependency Property for Path
        /// </summary>
        public static readonly DependencyProperty PathProperty =
            DependencyProperty.Register(nameof(Path), typeof(string), typeof(FolderBrowserDialogBehavior));
        /// <summary>
        /// Property wrapper for Path
        /// </summary>
        public string Path
        {
            get => (string) this.GetValue(PathProperty);
            set => this.SetValue(PathProperty, value);
        }
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Click += OnClick;
        }
        protected override void OnDetaching()
        {
            AssociatedObject.Click -= OnClick;
        }
        /// <summary>
        /// Triggered when the Button is clicked.
        /// </summary>
        private void OnClick(object sender, RoutedEventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                try
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        FilePath = dialog.SelectedPath;
                    }
                }
                catch (Exception ex)
                {
                    //Do something...
                }
            }
        }
    }
