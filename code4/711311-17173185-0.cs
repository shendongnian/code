    public class Program
    {
        public static string TargetDirectory = @"C:\MyDirectory";
    }
    
    public class SomeOtherClass
    {
        public void SomeMethod()
        {
            var directory = Program.TargetDirectory;
        }
    }
