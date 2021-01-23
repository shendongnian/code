using Microsoft.VisualBasic;
private void button1_Click(object sender, EventArgs e)
{
      string inputText = textBox1.Text;
      string singleByteString =  Strings.StrConv(inputText, VbStrConv.Narrow, 0);
      textBox2.Text = singleByteString;
      textBox3.Text = inputText;
}
    
