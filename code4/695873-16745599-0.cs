    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    
    namespace WinFormTest {
        public partial class Form1 : Form {
            private readonly IDictionary<Keys, bool> downState;
    
            public Form1() {
                InitializeComponent();
                downState = new Dictionary<Keys, bool>();
                downState.Add(Keys.W, false);
                downState.Add(Keys.D, false);
                KeyDown += remember;
                KeyUp += forget;
            }
    
            protected override void OnLoad(EventArgs e) {
                base.OnLoad(e);
                Timer timer = new Timer() { Interval = 100 };
                timer.Tick += updateGUI;
                timer.Start();
            }
    
            private void remember(object sender, KeyEventArgs e) {
                downState[e.KeyCode] = true;
            }
    
            private void forget(object sender, KeyEventArgs e) {
                downState[e.KeyCode] = false;
            }
    
            private void updateGUI(object sender, EventArgs e) {
                label1.Text = downState[Keys.W] ? "Forward" : "-";
                label2.Text = downState[Keys.D] ? "Right" : "-";
            }
        }
    }
