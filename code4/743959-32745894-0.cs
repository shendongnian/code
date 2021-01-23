        private void tableBorder_SizeChanged(object sender, EventArgs e)
        {
            new Thread(() => { resizeMe(); }).Start();
        }
        private void resizeMe()
        {
            Thread.Sleep(100);
            this.BeginInvoke((Action)(() => {
                doIt();
            }));
        }
        private void doIt()
        {
            splitContainer.Height = tableBorder.Height;
            splitContainer.Width = tableBorder.Width;
        }
