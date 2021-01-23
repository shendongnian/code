        private List<Tuple<Button, Int32, Int32>> listButton;
        private void SetButtons()
        {
            // TODO define what is n, left, top
            listButton = new List<Tuple<Button, int, int>>();
            for (int x = 5; x <= n; x++)
            {
                for (int y = 5; y <= n; y++)
                {
                    Button btn = new Button();
                    left += 72;
                    btn.Margin = new Thickness(left, top, 0, 0);
                    btn.Height = 32;
                    btn.Width = 32;
                    btn.Click += new RoutedEventHandler(btn_Click);
                    if (a[x, y] == 2)
                        btn.Background = Brushes.Red;
                    else
                        btn.Background = Brushes.Blue;
                    listButton.Add(new Tuple<Button, int, int>(btn, x, y));
                    main.Children.Add(btn);
                }
                left = 0;
                top += 72;
            }
        }
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            var tuple = listButton.Where(t => t.Item1 == button).FirstOrDefault();
            Int32 x = tuple.Item2;
            Int32 y = tuple.Item3;
            // Do whay you want this x and y found
        }
