    public class MyClass {
        public Form1 MyForm;
        
        public MyClass(Form1 form){
            this.MyForm = form;
        }
        public void echo(string text) {
            this.MyForm.textBox1.AppendText(text + Environment.NewLine);            
        }
    }
