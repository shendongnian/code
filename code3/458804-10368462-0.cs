       static void WriteStudent(Student S)
        {
            BinaryFormatter f = new BinaryFormatter();
            using (Stream w = new FileStream("c:\\list.dat", FileMode.Append))
            {
                f.Serialize(w, S);
            }
        }
        static List<Student> ReadStudents()
        {
            BinaryFormatter f = new BinaryFormatter();
            using (Stream w = new FileStream("c:\\list.dat", FileMode.Open))
            {
                List<Student> students = new List<Student>();
                while (w.Position < w.Length)
                {
                    students.Add((Student)f.Deserialize(w));
                }
                return students;
            }
        }
