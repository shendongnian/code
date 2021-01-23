        private void Button_GetTimeNow_Click(object sender, RoutedEventArgs e)
        {
            TextBlock_Now.Text = DateTime.Now.ToString();
        }
        private void Button_SaveTimeToISO_Click(object sender, RoutedEventArgs e)
        {
            m_Helper.WriteFile(TextBlock_Now.Text);
        }
        private void Button_GetTimeFromISO_Click(object sender, RoutedEventArgs e)
        {
            TextBlock_FromISO.Text = m_Helper.ReadFile();
            DateTime _loaded = DateTime.Parse(  TextBlock_FromISO.Text );
            TextBlock_Output.Text = _loaded.ToLongDateString();
        }
