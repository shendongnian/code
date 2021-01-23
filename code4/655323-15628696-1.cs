        private int Counter = 0;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Console.WriteLine(string.Format("X{0}, Y{1}\t Count = {2}", e.X, e.Y, Counter));
            Counter++;
            toolTip1.Show(
                string.Format("X{0}, Y{1}\t Count = {2}", e.X, e.Y, Counter),
                this.panel1,
                e.X - 75,
                e.Y -5);
        }
