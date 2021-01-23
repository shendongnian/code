        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            // fade out:
            this.Opacity = 1.0;
            for (double opacity = 1.0; opacity >= 0.0; opacity = opacity - .1)
            {
                System.Threading.Thread.Sleep(100);
                this.Opacity = opacity;
                Application.DoEvents();
            }
            // fade in:
            this.Opacity = 0.0;
            for (double opacity = 0.0; opacity <= 1.0; opacity = opacity + .1)
            {
                System.Threading.Thread.Sleep(100);
                this.Opacity = opacity;
                Application.DoEvents();
            }
            this.Opacity = 1.0;
            button1.Enabled = true;
        }
