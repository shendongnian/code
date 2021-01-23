        public void Populate()
        {
            BrowserInstance selectedItem = m_SelectedItem;
            List<BrowserInstance> items = new List<BrowserInstance>();
            foreach (Process process in Process.GetProcessesByName("chrome"))
                items.Add(new BrowserInstance(process));
            if (items.Count > 0)
            {
                m_Enabled = true;
                m_Items = new ObservableCollection<BrowserInstance>(items.OrderBy(x => x.Process.Id));
                if (selectedItem != null && selectedItem.Process != null)
                    selectedItem = m_Items.SingleOrDefault(x => (x.Process.Id == selectedItem.Process.Id) && (x.Process.MainModule.BaseAddress == selectedItem.Process.MainModule.BaseAddress));
                if (selectedItem == null)
                    selectedItem = m_Items[0];
            }
            else
            {
                m_Enabled = false;
                m_Items = new ObservableCollection<BrowserInstance>();
                m_Items.Add(new BrowserInstance());
                selectedItem = m_Items[0];
            }
            NotifyPropertyChanged("Enabled");
            NotifyPropertyChanged("Items");
            SelectedItem = selectedItem;
        }
