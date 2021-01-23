    // Controls:
    // pictureBox1
    // Dock: Fill
    // SizeMode: StretchImage
    // timer1
    
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;
    using System.Linq;
    
    namespace RandomImg
    {
        public partial class Form1 : Form
        {
            // List of files to show 
            private List<string> Files;
            
            public Form1()
            {
                InitializeComponent();
            }
    
            // StartUp 
            private void Form1_Load(object sender, EventArgs args)
            {
                // basic settings.
                var ext = new List<string> {".jpg", ".gif", ".png"};
    
                // we use same directory where program is.
                string targetDirectory = Directory.GetCurrentDirectory();
    
                // Here we create our list of files
                // New list
                // Use GetFiles to getfilenames
                // Filter unwanted stuff away (like our program)
                Files = new List<string>
                    (Directory.GetFiles(targetDirectory, "*.*", SearchOption.TopDirectoryOnly)
                    .Where(s => ext.Any(e => s.EndsWith(e))));
    
                // Create timer to call timer1_Tick every 3 seconds.
                timer1 = new System.Windows.Forms.Timer();
                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Interval = 3000; // 3 seconds
                timer1.Start();
    
                // Show first picture so we dont need wait 3 secs.
                ChangePicture();
            }
    
            private void timer1_Tick(object sender, EventArgs e)
            {
                // Time to get new one.
                ChangePicture();
            }
    
            private void ChangePicture()
            {
                // Do we have pictures in list?
                if (Files.Count > 0)
                {
                    // OK lets grab first one
                    string File = Files.First();
                    // Load it
                    pictureBox1.Load(File);
                    // Remove file from list
                    Files.RemoveAt(0);
                }
                else
                {
                    // Out of pictures, stopping timer
                    // and wait god todo someting.
                    timer1.Stop();
                }
            }
        }
    }
