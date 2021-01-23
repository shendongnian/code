        private void LoadData()
        {
            ServiceReference2.Service1Client webService = new ServiceReference2.Service1Client();
            webService.GetContentCompleted += new EventHandler<ServiceReference2.GetContentCompletedEventArgs>(webService_GetContentCompleted);
            webService.GetContentAsync();
        }
        private void webService_GetContentCompleted(object sender, ServiceReference2.GetContentCompletedEventArgs e)
        {
            IEnumerable<ServiceReference2.MediaContent> list = e.Result as IEnumerable<ServiceReference2.MediaContent>;
            dataGrid1.ItemsSource = list;
            ThirdMethod(list);
        }
        private void ThirdMethod(IEnumerable<ServiceReference2.MediaContent> list)
        {
            something = list;
        }
