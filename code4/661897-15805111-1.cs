    using System;
     
    public class Student{}
     
    public class Teacher : Student{}
     
    public class GenericClassWithTypeConstraints<T1, T2>
        where T1 : Student
        where T2 : Teacher
    {}
     
    class Test {
        static void Main() {
            var obj = new GenericClassWithTypeConstraints<Teacher, Teacher>();
        }
    }
