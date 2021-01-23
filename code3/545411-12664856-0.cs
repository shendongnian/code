    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        private async void button1_Click(object sender, EventArgs e) {
            var result = await FooAsync();
            label1.Text = result.ToString();
        }
        static async Task<int> FooAsync() {
            var t1 = Method1Async();
            var t2 = Method2Async();
            var result1 = await t1;
            var result2 = await t2;
            return result1 + result2;
        }
        static Task<int> Method1Async() {
            return Task.Run(
                () => {
                    Thread.Sleep(3000);
                    return 11;
                }
            );
        }
        static Task<int> Method2Async() {
            return Task.Run(
                () => {
                    Thread.Sleep(5000);
                    return 22;
                }
            );
        }
    }
