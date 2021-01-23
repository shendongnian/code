    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication19
    {
        public partial class Form1 : Form
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void textBox1_TextChanged(object sender, EventArgs e)
            {
                // cancel old query and datagrid update
                tokenSource.Cancel();
    
                tokenSource = new CancellationTokenSource();
                var token = tokenSource.Token;
    
                Task.Factory.StartNew((s) =>
                    {
                        var q = Task.Factory.StartNew<IEnumerable<DemoData>>(() => LongLastingDataQuery(textBox1.Text, token), token);
                        if (!token.IsCancellationRequested)
                            Task.Factory.StartNew(() => BindData(q.Result));
                    }, token);
            }
    
            private IEnumerable<DemoData> LongLastingDataQuery(string search, CancellationToken token)
            {
                List<DemoData> l = new List<DemoData>();
                for (int i = 0; i < 10000 * search.Length; i++)
                {
                    if (token.IsCancellationRequested)
                        return l;
    
                    l.Add(new DemoData { ID = i, Text = search + i, Text1 = search + i + i, Text2 = search + i + i + i, Text3 = search + i + i + i + i });
                }
                Thread.Sleep(1000);
                return l;
            }
    
            private void BindData(IEnumerable<DemoData> enumerable)
            {
                if (dataGridView1.InvokeRequired)
                    dataGridView1.Invoke(new MethodInvoker(() => BindData(enumerable)));
                else
                {
                    demoDataBindingSource.DataSource = null;
                    demoDataBindingSource.DataSource = enumerable;
                }
            }
    
            public class DemoData
            {
                public string Text { get; set; }
                public string Text1 { get; set; }
                public string Text2 { get; set; }
                public string Text3 { get; set; }
                public int ID { get; set; }
            }
        }
    }
