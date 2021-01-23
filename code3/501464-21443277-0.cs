{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        int click = 0;
        private void radioButton1_Click(object sender, EventArgs e)
        {
            click++;
            if (click %2==1)
            {
                radioButton1.Checked = true;
            }
            if (click %2==0)
            {
                radioButton1.Checked = false;
            }
            if (radioButton1.Checked==true)
            {
                label1.Text = "Cheked";
            }
            if (radioButton1.Checked==false)
            {
                label1.Text = "Uncheked";
            }
        }
       
    }
}
