    //This form contains textBox1
    public class Form1 : Form {
        public Form1(){
           InitializeComponent();
        }
        protected override bool ProcessTabKey(bool forward){
           if(textBox1.Focused) form2.FocusText();
           base.ProcessTabKey(forward);
        }
        Form2 form2 = new Form2();
    }
    //This form contains textBox2
    public class Form2 : Form {
        public Form2(){
           InitializeComponent();
           
        }
        public void FocusText(){
           textBox2.Focus();
        }
    }
