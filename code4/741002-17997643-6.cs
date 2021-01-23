    Student selectedStudent1;
            public Student SelectedStudent1
            {
                get { return selectedStudent1; }
                set {
                      selectedStudent=null;
                      selectedStudent1 = value;
                      Notify("SelectedStudent1"); }
            }
   
    Student selectedStudent;
            public Student SelectedStudent
            {
                get { return selectedStudent; }
                set {
                      selectedStudent1=null;
                      selectedStudent = value; 
                      Notify("SelectedStudent"); }
            }
