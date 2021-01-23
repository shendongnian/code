    public partial class Form1 : Form {
      public event EventHandler ImageMoved;
      private void OnImageMoved() {
        if (ImageMoved != null)
          ImageMoved(this, new EventArgs());
      }
      private void button1_Click(object sender, EventArgs e) {
        OnImageMoved();
      }
      private void button2_Click(object sender, EventArgs e) {
        Form2 f2 = new Form2(this);
        f2.Show();
      }
    }
