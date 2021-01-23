        public void display(BlockingCollection<BitmapImage> collection)
        {
            if (collection.IsCompleted || collection.Count != 0)
            {
                BitmapImage item = collection.Take();
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    this.dstSource.Source = item;
                }), DispatcherPriority.Normal);
            }
            else
            {
                dispatcherTimer.Stop();
            }
        }
        public void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            display(collection);
        }
        public void configureDispatcherTimer()
        {
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            TimeSpan interval = TimeSpan.FromMilliseconds(150);
            dispatcherTimer.Interval = interval;
        }
