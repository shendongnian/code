        private void body_MouseEnter(object sender, MouseEventArgs e)
        {
            foreach(var c in canvas.Children)
            {
                if(c is Shape) (c as Shape).Fill = Brushes.Red;
            }
        }
        private void body_MouseLeave(object sender, MouseEventArgs e)
        {
            foreach (var c in canvas.Children)
            {
                if (c is Shape) (c as Shape).Fill = Brushes.Blue;
            }
        }
