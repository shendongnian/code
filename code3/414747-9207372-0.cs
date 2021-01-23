    public class Form1 : Form
    {
        private static Form1 instance;
        public static Form1 Instance
        {
            get 
            { 
               if(instance == null) { instance = new Form1(); }
               return instance;
            }
        }
        private Form1()
        {
            ......
        }
    }
