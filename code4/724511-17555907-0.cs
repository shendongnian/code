    public partial class Prompt : Form
    {
          Timer timer;
          Label textLabel;
          TextBox textBox;
          Button confirmation;
          int count = 0;
          public Prompt()
          {
               InitializeComponent();
               this.Load += Prompt_Load;
               this.Width = 500;
               this.Height = 150;
               textLabel = new Label() { Left = 50, Top = 20, Text = "txt" };
               textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
               confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70 };
               this.Controls.Add(confirmation);
               this.Controls.Add(textLabel);
               this.Controls.Add(textBox);
               timer = new Timer();
               timer.Interval = 1000;
               timer.Tick += timer_Tick;
          }
        
          void Prompt_Load(object sender, EventArgs e)
          {
               timer.Start();
          }
        
          void timer_Tick(object sender, EventArgs e)
          {
               this.textLabel.Text = " " + count.ToString();
               count++;
               if (count == 10)
                   timer.Stop();
          }
    }
