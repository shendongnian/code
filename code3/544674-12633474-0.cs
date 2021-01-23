    public ClassThatHousesTheseFunctions(IUniversity university) {
        this._university = university;
    }
    
    public void SelectCourse(List<Course> courses) {
        if (this.IsFullTime) {
            performCourseSelection(courses, LEAST_NUM_OF_COURSES_FULLTIME);
        }
        else {
            performCourseSelection(courses, LEAST_NUM_OF_COURSES_PARTTIME);
        }       
    }
    private void performCourseSelection(IList<Course> courses, int leastNumberOfCourses) {
        Random rand = new Random();
    
        while (courses.Count < leastNumberOfCourses) {
            int i = rand.Next(courses.Count);
            Course c = courses.ToArray()[i];
            _university.RegisterStudentForCourse(this, c);
        }
        System.Console.WriteLine("Student: " + this.Name + ", with student number: (" + this.StudentNumber + ") registered.");
    }
