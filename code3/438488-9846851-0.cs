    public partial class Form1 : Form
    {
        private TimedEventsManager _timedEventsManager;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _timedEventsManager = new TimedEventsManager(this,
                                                         new TimedEvent(1000, () => textBox1.Text += "First\n"),
                                                         new TimedEvent(5000, () => textBox1.Text += "Second\n"),
                                                         new TimedEvent(2000, () => textBox1.Text += "Third\n")
                );
        }
        private void button1_Click(object sender, EventArgs e)
        {
            _timedEventsManager.Start();
        }
    }
    public class TimedEvent
    {
        public int Interval { get; set; }
        public Action Action { get; set; }
        public TimedEvent(int interval, Action func)
        {
            Interval = interval;
            Action = func;
        }
    }
    public class TimedEventsManager
    {
        private readonly Control _control;
        private readonly Action _chain;
        public TimedEventsManager(Control control, params TimedEvent[] timedEvents)
        {
            _control = control;
            Action current = null;
            // Create a method chain, beginning by the last and attaching it 
            // the previous.
            for (var i = timedEvents.Length - 1; i >= 0; i--)
            {
                var i1 = i;
                var next = current;
                current = () =>
                              {
                                  Thread.Sleep(timedEvents[i1].Interval);
                                   // MUST run it on the UI thread!
                                  _control.Invoke(new Action(() => timedEvents[i1].Action()));
                                  if (next != null) next();
                              };
            }
            _chain = current;
        }
        public void Start()
        {
            new Thread(new ThreadStart(_chain)).Start();
        }
    }
