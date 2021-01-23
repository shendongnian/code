    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Threading;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void cbSearch_TextUpdate(object sender, EventArgs e)
            {
                lastUpdate = DateTime.Now;
                allowUpdate = true;
            }
            DateTime lastUpdate = DateTime.Now;
            volatile bool allowUpdate = false;
            private void BoxUpdate()
            {
                while (true)
                {
                    Thread.Sleep(250);
                    if (allowUpdate)
                    {
                        var diff = DateTime.Now - lastUpdate;
                        if (diff.TotalMilliseconds > 1500)
                        {
                            allowUpdate = false;
                            this.InvokeEx(x =>
                            {
                                if (x.cbSearch.Text.Length > 0)
                                {
                                    x.PopulateCombo(cbSearch.Text);
                                }
                            });
                        }
                    }
                }
            }
            public void PopulateCombo(string text)
            {
                int sStart = cbSearch.SelectionStart;
                int sLen = cbSearch.SelectionLength;
                List<string> cbItems = new List<string>();
                for (int i = 0; i < 3; ++i)
                    for (int j = 0; j < 3; ++j)
                        cbItems.Add(i + text + j);
                cbSearch.Items.Clear();
                {
                    for (int i = 0; i < cbItems.Count; i++)
                    {
                        cbSearch.Items.Add(cbItems[i]);
                    }
                    cbSearch.DroppedDown = true;
                }
                cbSearch.SelectionStart = sStart;
                cbSearch.SelectionLength = sLen;
            }
            private void Form1_Shown(object sender, EventArgs e)
            {
                ThreadPool.QueueUserWorkItem(x =>
                {
                    BoxUpdate();
                });
            }
        }
        public static class ISynchronizeInvokeExtensions
        {
            public static void InvokeEx<T>(this T @this, Action<T> action)
                where T : System.ComponentModel.ISynchronizeInvoke
            {
                if (@this.InvokeRequired)
                {
                    @this.Invoke(action, new object[] { @this });
                }
                else
                {
                    action(@this);
                }
            }
        }
    }
