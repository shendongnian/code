    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                data = Enumerable.Range(10000, 1000000).Select(i => i.ToString()).ToArray();
            }
            async void button1_Click(object sender, EventArgs e)
            {
                label1.Text = "Reversing strings...";
                await doWork();
                label1.Text = "Reversed strings.";
            }
            Task doWork()
            {
                return Task.Factory.StartNew(() => Parallel.ForEach(data, (item, state, index) => data[index] = reverse(item)));
            }
            static string reverse(string s)
            {
                char[] charArray = s.ToCharArray();
                Array.Reverse(charArray);
                return new string(charArray);
            }
            readonly string[] data;
        }
    }
