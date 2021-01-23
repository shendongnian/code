    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Media;
    
    namespace TickCounter_MGilliland
    {
        public partial class Form1 : Form
        {
    
            int NumberOfTicks;
            SoundPlayer Song = new SoundPlayer("YellowSubCut.wav");
            bool AlarmGo = false;
    
    
            public Form1()
            {
                InitializeComponent();
    
                NumberOfTicks = 1;
    
                SecondTimer.Interval = 1000;
                SecondTimer.Enabled = true;
    
                Progress.Maximum = 100;
                Progress.Value = 0;
            }
    
            private void StartButton_Click(object sender, EventArgs e)
            {
                if (InputTicks.Text != string.Empty)
                {
                    try
                    {
                        // Get the number of ticks that the user wants and set the input to ""
                        NumberOfTicks = Int16.Parse(InputTicks.Text);
                        InputTicks.Text = string.Empty;
                    }
                    catch (Exception s)
                    {
                        MessageBox.Show("Exception: "+ s.ToString());
                        InputTicks.Text += " <-FixMe";
                    }
    
                    if (NumberOfTicks > 0)
                    {
                        // Set ShowTicks' text to the number of ticks and show it
                        ShowTicks.Text = NumberOfTicks.ToString();
                        ShowTicks.Show();
    
                        InputTicks.ReadOnly = true;
    
                        AlarmGo = true;
                        Progress.Value = Progress.Maximum = NumberOfTicks;
    
                        // Start the timer
                        SecondTimer.Start();
                    }
                    else
                        MessageBox.Show("Input Must be an unsigned number greater than 0!");
    
                }
                else
                    MessageBox.Show("I can't count ticks you haven't given, Sherlock!");
            }
    
            private void StopButton_Click(object sender, EventArgs e)
            {
                InputTicks.ReadOnly = false;
                SecondTimer.Stop();
                ShowTicks.Text = string.Empty;
                ShowTicks.Hide();
                Progress.Value = 0;
                Song.Stop();
                MessageBox.Show("Phew... I'm glad you stopped that...\nIt was really starting to tick me off.");
            }
    
            private void SecondTimer_Tick(object sender, EventArgs e)
            {
                if (NumberOfTicks > 0)
                {
                    // Decrease the number of ticks and change the value in ShowTicks
                    ShowTicks.Text = (--NumberOfTicks).ToString();
                    Progress.Value = NumberOfTicks;
                }
                else
                {
                    NumberOfTicks = 0;
                    SecondTimer.Stop();
                    if (AlarmGo)
                        Song.PlayLooping();
                    AlarmGo = false;
                }
            }
        }
    }
