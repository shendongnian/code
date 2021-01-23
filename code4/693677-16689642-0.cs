                private WeightType _selectedWeightType;
                public WeightType SelectedWeightType
                {
                    get { return _selectedWeightType; }
                    set
                    {
                        var previousType = _selectedWeightType;
                        _selectedWeightType = value;
                        NotifyPropertyChanged("SelectedWeightType");
                        if(previousType != null)
                            CurrentWeight = (CurrentWeight / previousType.Factor) * _selectedWeightType.Factor;
                    }
                }
