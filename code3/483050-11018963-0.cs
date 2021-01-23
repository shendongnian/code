    public class GridViewModel
    {
        // Kept this generic to reduce code here, but it
        // should be a full property with PropertyChange notification
        public ObservableCollection<GridRowModel> GridRows{ get; set; }
     
        public UsersViewModel()
        {
            GridRows = GetGridRows();
     
            // Add the validation delegate to the UserModels
            foreach(var row in GridRows)
                user.AddValidationErrorDelegate(ValidateGridRow);
        }
     
        // User Validation Delegate to verify UserName is unique
        private string ValidateGridRow(object sender, string propertyName)
        {
            if (propertyName == "Parameter")
            {
                var row = (GridRow)sender;
                var existingCount = GridRows.Count(p => 
                    p.Parameter == row.Parameter && p != row);
     
                switch(row.Parameter)
                {
                    case 1:
                        if (existingCount >= 0)
                            return string.Format("{0}s are already taken", row.Parameter);
                    case 2: case 5:
                        if (existingCount >= 1)
                            return string.Format("{0}s are already taken", row.Parameter);
                    case 3:
                        if (existingCount >= 2)
                            return string.Format("{0}s are already taken", row.Parameter);
                 }
            }
            return null;
        }
    }
