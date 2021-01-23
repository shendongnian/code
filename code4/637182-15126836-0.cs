    class TestClass
    {
        MyDate[] bd;
        Student[] s; 
        public TestClass()
        {
             bd = new MyDate[5] {  new MyDate(29, 3, 1990),
                                       new MyDate(30, 1, 1988),
                                       new MyDate(9, 6, 1987),
                                       new MyDate(2, 4, 1989),
                                       new MyDate(17, 8, 1986),
                                };
             s = new Student[5] { new Student("John", "BSCS"),
                                       new Student("Paul", "BSIT"),
                                       new Student("George", "BSCP"),
                                       new Student("Jane", "BSCS"),
                                       new Student("May", "BSIT")
                                 };
        }
    }
