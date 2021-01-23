    public class Main : Form
    {
         // assuming here you have three textboxes
         private void button1_Click(eventargs etc)
         {
             OtherForm otherForm = new OtherForm() { Text1 = textbox1.Text, 
                                                     Text2 = textbox2.Text,
                                                     Text3 = textbox3.Text };
             otherForm.Show();
         }
    }
    public class OtherForm : Form
    {
        public String Text1 { get; set; }
        public String Text2 { get; set; }
        public String Text3 { get; set; }
    }
