        public bool Ok = false;
        public void Do()
        {
            while (Ok)
            {
                this.Text += ".";
                System.Threading.Thread.Sleep(100);
                Application.DoEvents();
                //I added dots to the form text , You do your own mission
            }
        }
        private void btnLouder_MouseDown(object sender, MouseEventArgs e)
        {
            Ok = true;
            Do();
        }
        private void btnLouder_MouseUp(object sender, MouseEventArgs e)
        {
            Ok = false;
        }
