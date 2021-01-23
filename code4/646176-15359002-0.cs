    public partial class MediaPlayer : Form
    {
    public ImageViewer iv;
    public AudioPlayer ap;
    public VideoPlayer vp;
    public MediaPlayer()
    {
        InitializeComponent();
    }
    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (ofdSelectMedia.ShowDialog() == DialogResult.OK)
            switch(ofdSelectMedia.FilterIndex){
                case 1: 
                    new ImageViewer().Show();
                    toolStripButton1.PerformClick();
                    break;
                case 2: new AudioPlayer().Show();
                    break;
                case 3: new VideoPlayer().Show();
                    break;
       }
    }
