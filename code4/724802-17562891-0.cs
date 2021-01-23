    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                listBox1.DataSource = TaskQue.GetTasks();
            }
    
            private void Execute(object sender, EventArgs e)
            {
                string task = TaskQue.Pop();
                //execute task;
                listBox1.DataSource = TaskQue.GetTasks();
            }
    
            private void AddTask(object sender, EventArgs e)
            {
                TaskQue.Push(textBox1.Text);
                listBox1.DataSource = TaskQue.GetTasks();
    
            }
        }
    
        public class TaskQue
        {
            public static string txtPath = "C:/a.txt";
    
            public static string Pop()
            {
                StreamReader sr = new StreamReader(txtPath);
                string result = sr.ReadLine();
                string remaining = sr.ReadToEnd();
                sr.Close();
                StreamWriter sw = new StreamWriter(txtPath, false);
                sw.Write(remaining);
                sw.Close();
                return result;
            }
    
            public static void Push(string s)
            {
                
                StreamWriter sw = new StreamWriter(txtPath, true);
                sw.WriteLine(s);
                sw.Close();
            }
    
            public static IEnumerable<string> GetTasks()
            {
                return new List<string>(File.ReadLines(txtPath));
            }
        }
