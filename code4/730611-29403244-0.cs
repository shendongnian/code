    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Teacher();
            Console.Write(GetMemberName(() => person) + ": ");
            person.ShowInfo();
            Teacher teacher = new Teacher();
            Console.Write(GetMemberName(() => teacher) + ": ");
            teacher.ShowInfo();
            IPerson person1 = new Teacher();
            Console.Write(GetMemberName(() => person1) + ": ");
            person1.ShowInfo();
            IPerson person2 = (IPerson)teacher;
            Console.Write(GetMemberName(() => person2) + ": ");
            person2.ShowInfo();
            Teacher teacher1 = (Teacher)person1;
            Console.Write(GetMemberName(() => teacher1) + ": ");
            teacher1.ShowInfo();
            Person person4 = new Person();
            Console.Write(GetMemberName(() => person4) + ": ");
            person4.ShowInfo();
            IPerson person3 = new Person();
            Console.Write(GetMemberName(() => person3) + ": ");
            person3.ShowInfo();
            Console.WriteLine();
            Console.ReadLine();
        }
        private static string GetMemberName<T>(Expression<Func<T>> memberExpression)
        {
            MemberExpression expressionBody = (MemberExpression)memberExpression.Body;
            return expressionBody.Member.Name;
        }
    }
    interface IPerson
    {
        void ShowInfo();
    }
    public class Person : IPerson
    {
        public void ShowInfo()
        {
            Console.WriteLine("I am Person == " + this.GetType());
        }
        void IPerson.ShowInfo()
        {
            Console.WriteLine("I am interface Person == " + this.GetType());
        }
    }
    public class Teacher : Person, IPerson
    {
        public void ShowInfo()
        {
            Console.WriteLine("I am Teacher == " + this.GetType());
        }
    }
