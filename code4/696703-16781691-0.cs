    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Main");
            Console.ReadLine();
            Form oForm = new Form();
        }
    }
    public class Form
    {
        public Parent oParent;
        public Form()
        {
            Console.WriteLine("Form");
            Console.ReadLine();
            Parent oParent = new Parent(this);
        }
        public void TargetFunction()
        {
            Console.WriteLine("Target Hit");
            Console.ReadLine();
        }
    }
    public class Parent
    {
        Form oForm;
        Child oChild;
        public int hi = 1;
        public Parent(Form Form)
        {
            oForm = Form;
            Console.WriteLine("Parent");
            Console.ReadLine();
            oChild = new Child(oForm, this);
        }
    }
    public class Child
    {
        Form oForm;
        Parent oParent;
        public Child(Form Form, Parent Parent)
        {
            Console.WriteLine("Child");
            Console.ReadLine();
            oForm = Form;
            oParent = Parent;
            oForm.TargetFunction();
        }
    }
