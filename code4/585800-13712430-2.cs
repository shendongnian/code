    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace StudentManagement {
      public class Student {
        public static void Main(string[] args) {
          List<Student> students = new List<Student>();
          Console.Write("Enter number of students: ");
          int numStudents = int.Parse(Console.ReadLine());
          for (int i = 0; i < numStudents; i++) {
            Student s = new Student();
            students.Add(s);
          }
          Console.Write("Press any key to continue...");
          Console.ReadKey(true);
        }
        public string FirstName { get; set; }
        public List<Course> Courses { get; set; }
        public Student() {
          this.Courses = new List<Course>();
          Console.Write("Enter First Name: ");
          this.FirstName = Console.ReadLine();
          Console.Write("Enter in number of courses: ");
          int numCourses = int.Parse(Console.ReadLine());
          for (int i = 0; i < numCourses; i++) {
            Course course = new Course();
            this.Courses.Add(course);
          }
        }
      }
      public class Course {
        public string Title { get; set; }
        public string Code { get; set; }
        public string Section { get; set; }
        public List<Assignment> Assignments { get; set; }
        public Course() {
          this.Assignments = new List<Assignment>();
          // Set Title, Code, Section
          Console.Write("Enter nuber of assignments: ");
          int numAssignments = int.Parse(Console.ReadLine());
          for ( int i = 0; i < numAssignments; i++) {
            Assignment assignment = new Assignment();
            this.Assignments.Add(assignment);
          }
        }
      }
      public class Assignment {
        public string Name { get; set; }
        public double MaxGrade { get; set; }
        public double StudentGrade { get; set; }
        public Assignment() {
          // Prompt for Name, MaxGrade, StudentGrade
        }
      }
    }
