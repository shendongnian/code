    public partial class Form1 : Form
    {
        private Panel _myToolTipPanel;
        private void Form1_Load(object sender, EventArgs e)
        {
            _myToolTipPanel = new Panel {Visible = false};
            Controls.Add(_myToolTipPanel);
            Label myLabel = new Label();
            myLabel.Text = "Testing";
            _myToolTipPanel.Controls.Add(myLabel);
        }
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            _myToolTipPanel.Visible = false;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Point position = Cursor.Position;
            Point formPoisition = PointToClient(position);
            _myToolTipPanel.Visible = true;
            _myToolTipPanel.Location = formPoisition;
        }
    }
