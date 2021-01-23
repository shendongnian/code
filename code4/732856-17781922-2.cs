    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void MovePicturebox(Point p)
        {
            pictureBox1.Location = p;
        }
    }
    public static class MyClass
    {
        public static void DoWork()
        {
            //... code
            Program.myForm.MovePicturebox(new Point(10, 10));
            //... code
        }
    }
