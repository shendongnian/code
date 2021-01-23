    public class KeyNote
    {
        public long KeyNoteId { get; set; }
        public long CourseId { get; set; }
        public string CourseName { get; set; }
        public string Note { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    
    public List<KeyNote> KeyNotes { get; set; }
    public List<RefCourse> GetCourses { get; set; }    
    
    List<RefCourse> courses = KeyNotes.Select(x => new RefCourse { CourseId = x.CourseId, Name = x.CourseName }).Distinct().ToList();
