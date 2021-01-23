    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Session> sessions = new List<Session>();
            for (int i = 0; i < 5; i++)
            {
                List<Note> notes = new List<Note>();
                for (int j = i * 5; j < (i + 1) * 5; j++)
                {
                    Note note = new Note()
                    {
                        Notek = string.Format("Note {0}", j),
                        Details = string.Format("Note j = {0}{1}j*j = {2}", j, System.Environment.NewLine, j*j)
                    };
                    notes.Add(note);
                }
                Session session = new Session()
                {
                    Name = string.Format("Session # {0}", i),
                    Notes = notes
                };
                sessions.Add(session);
            }
            DataContext = sessions;
        }
    }
    public class Session
    {
        public string Name { get; set; }
        public List<Note> Notes { get; set; }
    }
    public class Note
    {
        public string Notek { get; set; }
        public string Details { get; set; }
    }
