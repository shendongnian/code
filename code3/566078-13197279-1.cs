    public partial class AsyncControlCreateTest : Form
    {
        object locker = new object();
        static List<ManualResetEvent> MREs = new List<ManualResetEvent>();
        Form loading = new Form() { Text = "Loading...", Width = 100, Height = 100 };
    
        public AsyncControlCreateTest()
        {
            InitializeComponent();       
        }
    
        private void AsyncControlCreateTest_Load(object sender, EventArgs e)
        {            
            loading.Show(this);//I want to close when all the async threads have completed
            CreateControls();
        }  
    
        private void CreateControls()
        {
            int startPoint= 0;            
            for (int i = 0; i < 100; i++)
            {
                ManualResetEvent mre = new ManualResetEvent(initialState: false);                
                UserControl control = new UserControl() { Text = i.ToString() };                
                control.Load += new EventHandler(control_Load);
                Controls.Add(control);
                control.Top = startPoint;
                startPoint += control.Height;
                MREs.Add(mre);
            }
            Task.Factory.StartNew(new Action(() =>
            {
                try
                {
                    WaitHandle.WaitAll(MREs.ToArray());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error " + ex.Message);
                }
                finally
                {
                    MessageBox.Show("MRE count = " + MREs.Count);//0 count provides confidence things are working...
                    loading.Invoke(new Action( () => loading.Close()));
                }
                
            }));
        }
    
        void control_Load(object sender, EventArgs e)
        {
            RichTextBox newRichTextBox = new RichTextBox();
            UserControl control = sender as UserControl;
            control.Controls.Add(newRichTextBox);            
    
            Task.Factory.StartNew(new Action(() => 
                {                    
                   Thread.Sleep(500);
                   newRichTextBox.Invoke(new Action(() => newRichTextBox.Text = "loaded"));
    
                   lock (locker)
                   {
                       var ev = MREs.First();
                       MREs.Remove(ev);
                       ev.Set();
                   }                   
                })); 
        }      
    }
