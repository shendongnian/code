    public partial class MainWindow : Window
    {
        private StringBuilder sb = new StringBuilder();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            switch (e.Key)
            {
                case Key.D0: { if (sb.Length == 2) sb.Insert(0, ','); sb.Insert(0, 0); break; }
                case Key.D1: { if (sb.Length == 2) sb.Insert(0, ','); sb.Insert(0, 1); break; }
                case Key.D2: { if (sb.Length == 2) sb.Insert(0, ','); sb.Insert(0, 2); break; }
                case Key.D3: { if (sb.Length == 2) sb.Insert(0, ','); sb.Insert(0, 3); break; }
                case Key.D4: { if (sb.Length == 2) sb.Insert(0, ','); sb.Insert(0, 4); break; }
                case Key.D5: { if (sb.Length == 2) sb.Insert(0, ','); sb.Insert(0, 5); break; }
                case Key.D6: { if (sb.Length == 2) sb.Insert(0, ','); sb.Insert(0, 6); break; }
                case Key.D7: { if (sb.Length == 2) sb.Insert(0, ','); sb.Insert(0, 7); break; }
                case Key.D8: { if (sb.Length == 2) sb.Insert(0, ','); sb.Insert(0, 8); break; }
                case Key.D9: { if (sb.Length == 2) sb.Insert(0, ','); sb.Insert(0, 9); break; }
            }
            textBox1.Text = sb.ToString();
        }
    }
