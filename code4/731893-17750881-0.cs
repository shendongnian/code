    public static class DataGridExtensions
    {
        public static DataGrid AllowColumnConfiguration(this DataGrid grid)
        {
            // Add NRE check
            grid.CanUserResizeColumns = true;
            grid.CanUserSortColumns = true;
            grid.CanUserReorderColumns = true;
    
            return grid;
        }
    
        public static DataGrid AllowEdition(this DataGrid grid)
        {
            // Add NRE check
            grid.CanUserAddRows = true;
            grid.CanUserDeleteRows = true;
    
            return grid;
        }
    }
