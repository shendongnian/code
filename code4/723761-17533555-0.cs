        private void ChangeCulture(string cultureKey)
        {
            try
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureKey);
            }
            catch (Exception err)
            {
                // That culture probably doesn't exist
            }
        }
        private void ButtonA_Click(object sender, EventArgs args)
        {
            ChangeCulture("en-US");
        }
        private void ButtonB_Click(object sender, EventArgs args)
        {
            ChangeCulture("de-DE");
        }
