    public class Form2 : Form
    {
        public string GetRichTextBoxContent()
        {
            return this.richTextBox1.Text;
        }
        public void SetRichTextBoxContent(string content)
        {
            this.richTextBox1.Text = content;
        } 
    }
    public class Form1 : Form
    {
        //Based on your implementation 
        Form2 form2 = new Form2();
        
        private void Button_CopyClick(object sender, EventArgs e)
        {
            //TODO: Implementation 
            var contentFromRtb = form2.GetRichTextBoxContent();
        } 
    }
