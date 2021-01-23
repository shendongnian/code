    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using WMPLib;
    namespace WindowsFormsApplication10
    {
        public partial class Form3 : Form
        {
            public Form3()
            {
                InitializeComponent();
                this.listBox2.DisplayMember = "Name";/*to display name on listbox*/
                this.listBox2.ValueMember = "FullName";/*to fetch item value on listbox*/
                Player.PlayStateChange += Player_PlayStateChange;
            }
            async void Player_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
            {
                if ((WMPLib.WMPPlayState)e.newState == WMPLib.WMPPlayState.wmppsMediaEnded)
                {
                    if (listBox2.SelectedIndex + 1 < listBox2.Items.Count)
                    {
                        await System.Threading.Tasks.Task.Delay(3000);
                        listBox2.SelectedItem = listBox2.Items[listBox2.SelectedIndex + 1];
                    }
                }
            }
            private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
            {
                Player.URL = Convert.ToString(listBox2.SelectedItem.GetType().GetProperty("FullName").GetValue(listBox2.SelectedItem)).ToString();
                Player.Ctlcontrols.play();
            }
        }
    }
