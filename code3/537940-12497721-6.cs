    public class ChildWindowVM : ViewModelBase
    {
        private ViewModelBase m_currentContent;
        public ViewModelBase CurrentContent
        {
            get { return m_currentContent; }
            set
            {
                NotifySetProperty(ref m_currentContent, value, () => CurrentContent);
                if (m_currentContent != null)
                {
                    m_currentContent.Refresh();
                    Messenger.Default.Send(new ShowChildWindowMessage());
                }
            }
        }
        public ChildWindowVM()
        {
            Messenger.Default.Register<DisplayDetailsMessage>(this, OnDisplayDetails);
        }
        private void OnDisplayDetails(DisplayDetailsMessage msg)
        {
            CurrentContent = ViewModelLocator.DetailsViewModel; // or whatever view model you want to display
        }
    }
