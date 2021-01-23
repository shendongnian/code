    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using WMPLib;
    namespace WindowsFormsApplication10
    {
        public partial class Form3 : Form
        {
            System.Timers.Timer _timer = new System.Timers.Timer();
            object _locker = new object();
            public Form3()
            {
                InitializeComponent();
                this.listBox2.DisplayMember = "Name";/*to display name on listbox*/
                this.listBox2.ValueMember = "FullName";/*to fetch item value on listbox*/
                Player.PlayStateChange += Player_PlayStateChange;
                _timer.Elapsed += _timer_Elapsed;
                _timer.Interval = 3000;
            }
            void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
            {
                _timer.Stop();
                lock (_locker)
                {
                    if (listBox2.SelectedIndex + 1 < listBox2.Items.Count)
                    {
                        listBox2.SelectedItem = listBox2.Items[listBox2.SelectedIndex + 1];
                    }
                }
            }
            void Player_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
            {
                if ((WMPLib.WMPPlayState)e.newState == WMPLib.WMPPlayState.wmppsMediaEnded)
                {
                    _timer.Start();
                }
                else if ((WMPLib.WMPPlayState)e.newState == WMPLib.WMPPlayState.wmppsReady)
                {
                    Player.Ctlcontrols.play();
                }
            }
            private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
            {
                Player.URL = Convert.ToString(listBox2.SelectedItem.GetType().GetProperty("FullName").GetValue(listBox2.SelectedItem, null)).ToString();
            }
        }
    }
