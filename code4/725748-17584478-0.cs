    using System.Windows.Forms;
    public partial class Main : Form
    {
      Timer myTimer = new Timer { Interval = 10000 };
      public void button_Click(object sender, EventArgs e)
      {
         myTimer.Tick += new EventHandler(OnTick);
         myTimer.Start();
      }
      public void OnTick(object sender, EventArgs ea)
      {
         myTimer.Stop();
         Message.Show(textbox1.Text);
      }
     }
