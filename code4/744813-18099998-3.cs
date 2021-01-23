    public partial class Form1 : Form
    {
        List<object> _queue = new List<object>();
        bool _paused = false;
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("Id", "Id");
            var h = new Hardware();
            h.Send += h_Send;
        }
        void h_Send(object sender, EventArgs e)
        {
            var value = ((Hardware.SendArgs)e).Id;
            if (_paused)
            {
                _queue.Add(value);
            }
            else
            {
                if (this.InvokeRequired)
                {
                    BeginInvoke(new MethodInvoker(delegate()
                    {
                        dataGridView1.Rows.Add(value);
                    }));
                }
            }
        }
        private void pauseButton_Click(object sender, EventArgs e)
        {
            _paused = !_paused;
            pauseButton.Text = (_paused) ? "Start" : "Pause";
            if (!_paused)
                if (this.InvokeRequired)
                {
                    BeginInvoke(new MethodInvoker(delegate()
                    {
                        _queue.ForEach(item =>
                        {
                            dataGridView1.Rows.Add(item);
                        });
                        _queue.Clear();
                    }));
                }
                else
                {
                    _queue.ForEach(item =>
                    {
                        dataGridView1.Rows.Add(item);
                    });
                    _queue.Clear();
                }
        }
    }
