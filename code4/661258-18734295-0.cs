            /// <summary>
            /// Handles the Loaded event of the Window control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                this.Dispatcher.BeginInvoke(DispatcherPriority.Background, new LoadDataDelegate(LoadData));
            }
    
            private delegate void LoadDataDelegate();
    
            /// <summary>
            /// Loads the data.
            /// </summary>
            private void LoadData()
            {
                List<string> numberDescriptions = new List<string>();
                for (int i = 1; i <= 10000000; i++)
                {
                    
                    numberDescriptions.Add("Number " + i.ToString());
                }
                listBox1.ItemsSource = numberDescriptions;
            }
