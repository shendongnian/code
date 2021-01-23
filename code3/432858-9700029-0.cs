        private void Panorama_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OldPage = ActualPage;
            ActualPage = panorama.SelectedIndex;
            MessageBox.Show("Old page: " + OldPage + "\n Actual Page: " + ActualPage);
            if (OldPage < ActualPage)
                MessageBox.Show("Direction of the slide: Right");
            else if (OldPage > ActualPage)
                MessageBox.Show("Direction of the slide: Left");
            // else if( some other specific condition...)
        }
        private int OldPage { get; set; }
        private int ActualPage { get; set; }
