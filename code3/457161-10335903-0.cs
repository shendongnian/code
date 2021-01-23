    public class YourForm : Form
    {
    
      private class ProgressInfo
      {
        public ProgressInfo(ulong top, ulong direct, ulong diffuse, ulong absorbed, ulong failed, ulong photons)
        {
          // Set properties here.
        }
    
        public ulong Top { get; private set; }
        public ulong Direct { get; private set; }
        public ulong Diffuse { get; private set; }
        public ulong Dbsorbed { get; private set; }
        public ulong Failed { get; private set; }
        public ulong Photons { get; private set; }
      }
    
      private volatile ProgressInfo progress = null;
    
      private void calculateModel()
      {
        for (ulong photonCount = 0; photonCount < photons; photonCount++)
        {
          // Do your calculations here.
          // Publish new progress information.
          progress = new ProgressInfo(/* ... */);
        }
      }
    
      private void UpdateTimer_Tick(object sender, EventArgs args)
      {
        // Get a local reference to the data structure.
        // This is all that is needed since ProgressInfo is immutable
        // and the member was marked as volatile.
        ProgressInfo local = progress;
        this.textBoxAlbedo.Text = ((double)local.Top / (double)local.Photons).ToString();
        this.textBoxDirect.Text = ((double)local.Direct / (double)local.Photons).ToString();
        this.textBoxDiffuse.Text = ((double)local.Diffuse / (double)local.Photons).ToString();
        this.textBox1.Text = local.Absorbed.ToString();
        this.textBox2.Text = local.Failed.ToString();
      }
