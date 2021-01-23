        /// <summary>
        /// Test to show launching on screen board (osk.exe).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(@"c:\Temp\OSK.exe");
            }
            catch (Exception error)
            {
                string err = error.ToString();
            }
        }
