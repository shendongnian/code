    using System;
    using System.Windows.Forms;
    
    class Program
    {
        static void Main(string[] args)
        {
            string foo = "FOO";
            switch (foo)
            {
                case "FOO":
                    MessageBox.Show("Dog");
                    MessageBox.Show("Cat");
                    break;
            }
        }
    }
