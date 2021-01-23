        public string PlanPerfID_Proxy
        {
          get { return SelectedReport.PlanPerfID; }
          set
          {
            if (!_settingCombos)
            {
              SelectedReport.PlanPerfID = value;
              NotifyPropertyChanged("PlanPerfID_Proxy");
            }
          }
        }
