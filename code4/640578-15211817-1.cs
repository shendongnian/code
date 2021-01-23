    object m_ImagesLock = new object();
    private List<Image> m_ImagesLoading = new List<Image>();
    private void Image_Loaded_1(object sender, RoutedEventArgs e)
    {
        lock (m_ImagesLock)
        {
            var _Image = sender as Image;
            m_ImagesLoading.Add(_Image);
            var _Action = new Action(() =>
            {
                m_ImagesLoading.Remove(_Image);
                ImageContainer.Opacity = m_ImagesLoading.Any() ? 0 : 1;
            });
            _Image.ImageOpened += (s, arg) => _Action();
            _Image.ImageFailed += (s, arg) => _Action();
        }
    }
