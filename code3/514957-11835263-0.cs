    public class Student
    {
        string studentID = string.Empty;
        public string StudentID
        {get { return studentID;}
         set { studentID = value;}}
    };
    public class Course
    {
        string courseID = string.Empty;
        public string CourseID
        {get { return courseID;}
         set { courseID = value;}}
    };
    public class Enrollment
    {
        Student studentData = new Student();
        public Student StudentData
        {get { return studentData;}
         set { studentData = value;}
        }
        Course courseData = new Course();
        public Course CourseData
        {get { return courseData; }
         set { courseData = value; }}
    };
    public class StudentScore
    {
        Enrollment enrollmentData = new Enrollment();
        public Enrollment EnrollmentData
        {get { return enrollmentData;}
         set { enrollmentData = value;}}
        int score = 0;
        public int Score
        {get {return score;}
         set {score = value;}}
    };
    public List<StudentScore> getScoreList()
    {
        List<StudentScore> aStudentScore = new List<StudentScore>();
        StringBuilder tmpSQL = new StringBuilder();
        tmpSQL.Append("SELECT c.CourseID, en.Score, s.StudentID ");
        tmpSQL.Append("FROM EnrollmentTable en ");
        tmpSQL.Append("       INNER JOIN Student s ON en.StudentID = s.StudentID ");
        tmpSQL.Append("       INNER JOIN Course c ON en.CourseID = c.CourseID ");
        try
        {using (SqlConnection conn = MyDB.GetConnection()){
           conn.Open();
           using (SqlCommand command = new SqlCommand(tmpSQL.ToString(), conn)){
             using (SqlDataReader reader = command.ExecuteReader()){
               while (reader.Read())
                 {
                  StudentScore score = new StudentScore();
                  score.EnrollmentData.StudentData.StudentID = reader["StudentID"].ToString();
                  score.EnrollmentData.CourseData.CourseID = reader["CourseID"].ToString();
                  score.Score = Convert.ToInt32(reader["Score"]);
                  aStudentScore.Add(score);
                  };
                };
             };
          };
        }
        catch (Exception ex)
        {throw ex;}
        return aStudentScore; 
    }
