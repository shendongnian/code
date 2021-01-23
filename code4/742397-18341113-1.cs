    public class MainForm : Form {
        public MainForm() {
            Test t = new Test();
    
            Thread testThread = new Thread((ThreadStart)delegate { t.HelloWorld(this); });
            testThread.IsBackground = true;
            testThread.Start();
        }
    
        public void UpdateTextBox(string text) {
            Invoke((MethodInvoker)delegate {
                textBox1.AppendText(text + "\r\n");
            });
        }
    }
    
    public class Test {
        public void HelloWorld(MainForm form) {
            form.UpdateTextBox("Hello World"); 
        }
    }
