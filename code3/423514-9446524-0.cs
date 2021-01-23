    namespace Employee_Card_Manager 
    { 
        public partial class Form1 : Form 
        { 
            ProgressBar pBar = new ProgressBar(); 
            string Chosen_File = ""; 
     
            public Form1() 
            { 
                InitializeComponent(); 
                CreateProgressBar();
            } 
            private void CreateProgressBar() 
            { 
                pBar.Location = new System.Drawing.Point(20, 20); 
                pBar.Name = "progressBar1"; 
                pBar.Width = 200; 
                pBar.Height = 30; 
                pBar.BackColor = Color.Transparent;
                pBar.Minimum = 0; 
                pBar.Maximum = 100; 
                pBar.Value = 0; 
                Controls.Add(pBar); 
            } 
    
            private void button1_Click(object sender, EventArgs e) 
            { 
                selectpic.Title = "Browse Employee Picture!"; 
                selectpic.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal); 
                selectpic.FileName = ""; 
                selectpic.Filter = "JPEG Images|*.jpg|GIF Images|*.gif|BITMAPS|*.bmp"; 
     
                if (selectpic.ShowDialog() != DialogResult.Cancel) 
                { 
                    Chosen_File = selectpic.FileName; 
                    pictureBox1.LoadCompleted += new AsyncCompletedEventHandler(pictureBox1_LoadCompleted);
                    pictureBox1.LoadProgressChanged += new ProgressChangedEventHandler(pictureBox1_LoadProgressChanged);
                    pictureBox1.WaitOnLoad = false;
                    pictureBox1.LoadAsynch(Chosen_file);
                } 
            } 
            
            private void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
            {
                pBar.Value = 0;
            }
    
            private void pictureBox1_LoadProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                pBar.Value = e.ProgressPercentage;
            }    
        }
    } 
