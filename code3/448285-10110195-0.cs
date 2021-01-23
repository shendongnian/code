        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Dispatcher.BeginInvoke(new Action(delegate
            {
                // do stuff
            }
            ));
        }
