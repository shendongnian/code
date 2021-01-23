    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void onButtonClick(object sender, EventArgs e)
        {
            RunNpc1();
            RunNpc2();
        }
        public async void RunNpc1()
        {
            while (true)
            {
                await _npc1.MoveTo(20);
                await _npc1.MoveTo(10);
            }
        }
        public async void RunNpc2()
        {
            while (true)
            {
                await _npc2.MoveTo(80);
                await _npc2.MoveTo(70);
            }
        }
        NpcTest _npc1 = new NpcTest();
        NpcTest _npc2 = new NpcTest();
        private void timer1_Tick(object sender, EventArgs e)
        {
            _npc1.onFrame();
            _npc2.onFrame();
            label1.Text = _npc1.Position.ToString();
            label2.Text = _npc2.Position.ToString();
        }
    }
