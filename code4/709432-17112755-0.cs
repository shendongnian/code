     if (m_SelectedQueryModule != value)
            {
                m_SelectedQueryModule = value;
                OnPropertyChanged("SelectedQueryModule");
                var queryNames = _service.GetQueryNames(m_SelectedQueryModule);
            
                m_queryNames = new Dictionary<int, string>(queryNames);
            
                //RAISE PROPERTY CHANGED AFTER YOU SET NEW VALUE FOR m_queryNames
                OnPropertyChanged("QueryNames");
           
                m_ReadOnlyQueryNames = new Dictionary<int, string>(m_queryNames);
                OnPropertyChanged("SelectedQueryNames");
     
            }
