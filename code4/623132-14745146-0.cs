        private void listView_MouseMove(object sender, MouseEventArgs e)
        {
            var item = Mouse.DirectlyOver;
            if (item != null && item is TextBlock)
                Debug.Print((item as TextBlock).Text);
        }
