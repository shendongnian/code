    //textBox1 is on your form1
    if(form2.ShowDialog(textBox1.Text) == DialogResult.OK){
       dataGridView1.CurrentCell.Value = form2.Notes;
       //perform you update to xml normally
       //.....
    }
    //your Form2
    public class Form2 : Form {
       public Form2(){
          InitializeComponent();
       }
       public string Notes {get;set;}
       public DialogResult ShowDialog(string initText){
          //suppose textBox is on your form2.
          textBox.Text = initText;
          return ShowDialog();
       }
       private void OKButton_Click(object sender, EventArgs e){
          Notes = textBox.Text;
          DialogResult = DialogResult.OK;
       }
       private void CancelButton_Click(object sender, EventArgs e){
          DialogResult = DialogResult.Cancel;
       }
    }
    //form2 is defined in your Form1 class.
