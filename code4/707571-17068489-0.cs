    public class Form2 : Form
    {
        //define the event
        public event Action<Color, Size> ColorChosen;
        private void panel1_Click(object sender, EventArgs e)
        {
            //raise the event
            var panel = (Panel)sender;
            ColorChosen(panel.BackColor, panel.Size);
            Close();
        }
    }
