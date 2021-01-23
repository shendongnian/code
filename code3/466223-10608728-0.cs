    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void OnClick(object sender, EventArgs e)
            {
                backgroundWorker1.RunWorkerAsync();
            }
            private void OnDoWork(object sender, DoWorkEventArgs e)
            {
                foreach (ListViewItem i in GetItems(listView1))
                {
                    DoSomething(i);
                }
            }
            private IEnumerable<ListViewItem> GetItems(ListView listView)
            {
                if (InvokeRequired)
                {
                    var func = new Func<ListView, IEnumerable<ListViewItem>>(GetItems);
                    return (IEnumerable<ListViewItem>)Invoke(func, new[] { listView });
                }
                // Create a defensive copy to avoid iterating outsite UI thread
                return listView.CheckedItems.OfType<ListViewItem>().ToList();
            }
            private void DoSomething(ListViewItem item)
            {
                if (InvokeRequired)
                {
                    var action = new Action<ListViewItem>(DoSomething);
                    Invoke(action, new[] { item });
                    return;
                }
                // Do whatever you want with i
                item.Checked = false;
            }
        }
    }
