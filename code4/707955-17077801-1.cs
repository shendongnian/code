    public class InputBox
    {
        private string _title;
        public InputBox(string title)
        {
            _title = title;
        }
        public static implicit operator string(InputBox from)
        {
            return from._title;
        }
    }
    // .. elsewhere ..
     string title = new InputBox("Test");
     Console.WriteLine(title); // prints Test
