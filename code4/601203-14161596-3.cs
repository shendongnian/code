    using Windows.UI.Xaml.Controls;
    namespace App84
    {
        public sealed partial class MainPage : Page
        {
            public MainPage()
            {
                this.InitializeComponent();
            }
            private void ScrollViewer_OnViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
            {
                OffsetTextBlock.Text =
                    ManipulationCaptureScrollViewer.VerticalOffset.ToString();
            }
        }
    }
