    public partial class ChildForm : Form
    {
        public ChildForm()
        {
            // createButton here
        }
        private void button_Click(object sender, EventArgs e)
        {
            ChildForm _childForm = new ChildForm();
            _childForm.Owner = this;
            _childForm.Number = this.Number + 1;
            this.Hide();
            _childForm.Show();
        }
        public void FirstChildForm()
        {
            if (this.Number != 1) //maybe not that static
            {
                (this.Owner as ChildForm).FirstChildForm();
                this.Close(); // or hide or whatever
            }
        }
        public int Number
        { get; set; }
    }
