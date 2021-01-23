    public partial class Form1 : Form {
      Form2 f2;
      public Form1() {
        InitializeComponent();
        this.LocationChanged += new EventHandler(Form1_LocationChanged);
      }
      private void button1_Click(object sender, EventArgs e) {
        f2 = new Form2();
        f2.StartPosition = FormStartPosition.Manual;
        f2.Location = new Point(this.Right, this.Top);
        f2.Height = this.Height;
        f2.Show();
      }
      void Form1_LocationChanged(object sender, EventArgs e) {
        if (f2 != null)
          f2.Location = new Point(this.Right, this.Top);
      }
    }
