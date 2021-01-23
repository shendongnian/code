        public class NoteView
        {
            public string Filename { get; set; }
            public string Contents { get; set; }
        }
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var noteList = new ObservableCollection<NoteView>();
            for (int i = 0; i < 10; i++)
            {
                noteList.Add(new NoteView { Filename = "Sample note " + i });
            }
            NotesList.ItemsSource = noteList;
        }
