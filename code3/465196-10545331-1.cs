    public partial class Form1 : Form                    
    {
      private ConcurrentQueue<string> queue = new ConcurrentQueue<string>();
    
      public Form1()                    
      {                    
        InitializeComponent();                    
      }                    
                        
      private void Form1_Load(object sender, EventArgs e)                    
      {                    
        console.Items.Clear();                    
        console.Items.Add("test");
        players.Items.Clear();                    
        players.Items.Add("Witaj w serwerze");                    
        Task.Factory.StartNew(
          () =>
          {
            while (GetSomeCondition())
            {
              string value = GetSomeValue();
              queue.Enqueue(value);
            }
          });
      }                    
                        
      private void YourTimer_Tick(object sender, EventArgs e)                    
      {                    
        string value;
        while (queue.TryDequeue(out value)
        {
          console.Items.Add(value);
        }
      }                                        
    }                    
