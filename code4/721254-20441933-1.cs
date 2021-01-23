    using Microsoft.DirectX.AudioVideoPlayback;
    namespace Play_Video
    {
    public partial class Form1 : Form
    {
        Video vdo;
      
        public string mode="play";
        public string PlayingPosition, Duration;
        public Form1()
        {
            InitializeComponent();
            VolumeTrackBar.Value = 4;
        }
      
        private void timer1_Tick(object sender, EventArgs e)
        {
           
            PlayingPosition = CalculateTime(vdo.CurrentPosition);
            txtStatus.Text = PlayingPosition + "/" + Duration;
            
            if (vdo.CurrentPosition >= vdo.Duration)
            {
                timer1.Stop();
                Duration = CalculateTime(vdo.Duration);
                PlayingPosition = "0:00:00";
                txtStatus.Text = PlayingPosition + "/" + Duration;
                vdo.Stop();
                btnPlay.BackgroundImage = Play_Video.Properties.Resources.btnplay;
                vdoTrackBar.Value = 0;
            }
            else
                vdoTrackBar.Value += 1;
         
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (vdo != null)
            {
                vdo.Stop();
                timer1.Stop();
                btnPlay.BackgroundImage = Play_Video.Properties.Resources.btnplay;
                vdoTrackBar.Value = 0;
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            openFileDialog1.Title = "Select video file..";
            openFileDialog1.InitialDirectory = Application.StartupPath;
            openFileDialog1.DefaultExt = ".avi";
            openFileDialog.Filter = "Media Files|*.mpg;*.avi;*.wma;*.mov;*.wav;*.mp2;*.mp3|All Files|*.*";
            if (openFileDialog1.FileName != "")
            {
                Form1.ActiveForm.Text = openFileDialog.FileName + " - Anand Media Player";
                vdo = new Video(openFileDialog.FileName);
                vdo.Owner = panel1;
                panel1.Width = 700;
                panel1.Height = 390;
                Duration = CalculateTime(vdo.Duration);
                PlayingPosition = "0:00:00";
                txtStatus.Text = PlayingPosition + "/" + Duration;
                vdoTrackBar.Minimum = 0;
                vdoTrackBar.Maximum = Convert.ToInt32(vdo.Duration);
            }
        }
        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (vdo != null)
            {
                if (vdo.Playing)
                {
                    vdo.Pause();
                    timer1.Stop();
                    btnPlay.BackgroundImage = Play_Video.Properties.Resources.btnplay;
                }
                else
                {
                    vdo.Play();
                    timer1.Start();
                    btnPlay.BackgroundImage = Play_Video.Properties.Resources.pause;
                }
            }
                       
        }
       
        private void btnStop_Click(object sender, EventArgs e)
        {
            vdo.Stop();
            timer1.Stop();
            btnPlay.BackgroundImage = Play_Video.Properties.Resources.btnplay;
            vdoTrackBar.Value = 0;
        }
        public string CalculateTime(double Time)
        {
            string mm, ss, CalculatedTime;
            int h, m, s, T;
            Time = Math.Round(Time);
            T = Convert.ToInt32(Time);
            h = (T / 3600);
            T = T % 3600;
            m = (T / 60);
            s = T % 60;
            if (m < 10)
                mm = string.Format("0{0}", m);
            else
                mm = m.ToString();
            if (s < 10)
                ss = string.Format("0{0}", s);
            else
                ss = s.ToString();
            CalculatedTime = string.Format("{0}:{1}:{2}", h, mm, ss);
            return CalculatedTime;
        }
        private void VolumeTrackBar_Scroll(object sender, EventArgs e)
        {
            if (vdo != null)
            {
                vdo.Audio.Volume = CalculateVolume();
            }
        }
        public int CalculateVolume()
        {
          switch (VolumeTrackBar.Value)
            {
                case 1:
                    return -1500;
                case 2:
                    return -1000;
                case 3:
                    return -700;
                case 4:
                    return -600;
                case 5:
                    return -500;
                case 6:
                    return -400;
                case 7:
                    return -300;
                case 8:
                    return -200;
                case 9:
                    return -100;
                case 10:
                    return 0;
                default:
                    return -10000;
            }
        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            Duration = CalculateTime(vdo.Duration);
            PlayingPosition = "0:00:00";
            txtStatus.Text = PlayingPosition + "/" + Duration;
        }
        private void vdoTrackBar_Scroll(object sender, EventArgs e)
        {
            if (vdo != null)
            {
                vdo.CurrentPosition = vdoTrackBar.Value;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }
        private void exitToolItem_Click(object sender,EventArgs e)
        {
            Application.Exit();
        }
    }
    }
