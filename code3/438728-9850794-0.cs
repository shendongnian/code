    class Student
    {
        string name;
        string candidate_number;
        string student_id;
        // One to many
        List<Enrollment> modules;
    }
    class Enrollment
    {
        Subject subject;
        // One to many
        List<Exam> exams;
    }
    class Subject
    {
        string subject_code;
    }
    class Exam
    {
        int attempt;
        string year;
        int mark;
        char grade;
    }
