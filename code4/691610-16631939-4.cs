    public partial class Form1 : Form
    {        
        public Button BtnShowForm2
        {
            get { return btnShowForm2; }
            set { btnShowForm2 = value; }
        }
        
        private void btnShowForm2_Click(object sender, EventArgs e)
        {
            // pass the current form to form2
            Form2 form = new Form2(this);
            form.Show();
        }
    }
