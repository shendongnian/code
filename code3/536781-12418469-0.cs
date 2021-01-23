    public class StudentHandler
    {
        ObservableCollection<student> m_myGroup;
        public CollectionViewSource YoungStudentsViewSource { get; private set; }
        public CollectionViewSource OldStudentsViewSource { get; private set; }
        public StudentHandler
        {
            YoungStudentsViewSource = new CollectionViewSource {Source = m_myGroup};
            OldStudentsViewSource = new CollectionViewSource {Source = m_myGroup}; 
            YoungStudentsViewSource.Filter = (stud) => {return (stud as student).age<=25;};
            OldStudentsViewSource .Filter = (stud) => {return (stud as student).age>25;};
        }
    }
