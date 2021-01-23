    using System.Diagnostics;
    using System.Windows;
    namespace DevBindingErrors
    {
        /// <summary>
        /// Interaction logic for App.xaml
        /// </summary>
        public partial class App : Application
        {
            public App()
            {
                PresentationTraceSources.Refresh();
                PresentationTraceSources.DataBindingSource.Listeners.Add(new BindingTraceListener());
                PresentationTraceSources.DataBindingSource.Switch.Level = SourceLevels.Warning;
            }
        }
    }
