    public partial class Form1 : Form
       {
          private readonly int m_numOfSteps;
    
          public Form1(int numOfSteps)
          {
             m_numOfSteps = numOfSteps;
             InitializeComponent();
          }
    
          private void Form1_Load( object sender, EventArgs e )
          {
             progressBar1.Step = (int)Math.Ceiling( 100.0 / m_numOfSteps );
          }
    
          public void DoStep(string msg)
          {
             progressBar1.PerformStep();
             label1.Text = msg;
             label2.Text = String.Format( "{0}%", progressBar1.Value  );
             label1.Refresh();
             label2.Refresh();
          }
       }
    
       public partial class Form2 : Form
       {
          public Form2()
          {
             InitializeComponent();
          }
    
          private void button1_Click( object sender, EventArgs e )
          {
             using( Form1 f = new Form1( 3 ) )
             {
                f.Show();
                f.Refresh();
                Thread.Sleep( 1000 );
                f.DoStep( "AAAA" );
                Thread.Sleep( 1000 );
                f.DoStep( "BBBB" );
                Thread.Sleep( 1000 );
                f.DoStep( "CCCC" );
                Thread.Sleep( 1000 );
             }
          }
       }
