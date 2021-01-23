    namespace ClassLibrary
    {
        public class Utility
        {
            public static string ReadData()
            {
                return "abc";
            }
        }
    }
    namespace Win_App
    {
        public partial class Form1 : Form
        {
           private void button2_Click(object sender, EventArgs e)
           {
                if (ClassLibrary.Utility.ReadData() == null)
                {
                    MessageBox.Show("error, redo");
                    button2.Focus(); //you should handle this here.
                    return;
                }
            }
        }
    }
