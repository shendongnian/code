    public void CourseFormViewModel()
        {
            Schools = new ObservableCollection<School>();
    
            try
            {
                // Gets schools from a web service and adds them to the Schools ObservableCollection
                PopulateSchools();
    
                SelectedSchool = 3;
            }
            catch (Exception ex)
            {
                // ...
            }
        }
