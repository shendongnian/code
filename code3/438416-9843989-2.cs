    partial class Window1 {
        void button3Click(object sender, RoutedEventArgs e) {
            //Whatever you want here
        }
        void button2Click(object sender, RoutedEventArgs e) {
            //Whatever you want here
        }
        void button1Click(object sender, RoutedEventArgs e) {
            //Whatever you want here
        }
        public Window1() {
            this.InitializeComponent();
            populateButtons();
        }
        public void populateButtons() {
            int xPos;
            int yPos;
            Random ranNum = new Random();
            foreach (var routedEventHandler in new RoutedEventHandler[] { button1Click, button2Click, button3Click }) {
                Button foo = new Button();
                int sizeValue = ranNum.Next(100);
                foo.Width = sizeValue;
                foo.Height = sizeValue;
                xPos = ranNum.Next(200);
                yPos = ranNum.Next(300);
                foo.HorizontalAlignment = HorizontalAlignment.Left;
                foo.VerticalAlignment = VerticalAlignment.Top;
                foo.Margin = new Thickness(xPos, yPos, 0, 0);
                foo.Click += routedEventHandler;
                LayoutRoot.Children.Add(foo);
            }
        }
    }
