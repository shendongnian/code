    class Program
    {
        public static object abc;
        static void Main(string[] args)
        {
            //do something here if required
            Form1 frm = new Form1();
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //login success do what ever on success
                Console.WriteLine("Login success");
                Console.WriteLine(abc.ToString());
            }
            else
            {
                Console.WriteLine("Login failure");
                Console.WriteLine(abc.ToString());
                //login failure
            }
            Console.ReadLine();
        }
    }
