        Visibility.VisibilityLevel _vizibility;
        public Visibility.VisibilityLevel Visibility{
            get {
                if (_vizibility != Models.Visibility.VisibilityLevel.ShowThis)  //the default
                    return _hide_data;
                var ans =  new MacDirectEntities()
                ...
                return ans.Visibility;
            }
            set {
                _vizibility= value;
            }
        }
    }
