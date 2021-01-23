    public class Form1:Form 
    {
        public DataSet Data { get; set; }
        public void ShowForm2()
        {
            Form2 child = new Form2(this);
        }
    }
    public class Form2 : Form
    {
        public Form2(Form1 parent) { Parent = parent; }
        public Form1 Parent { get; set; }
        public void SomeMethod()
        {
            // now you can use the DataSet of Form1 via Parent proprty:
            DataSet data = this.Parent.Data;
        }
    }
