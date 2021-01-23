    public static class GridProvider
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataTable GetData(int MenuItemId)
        {
            return GuiCreators.getDataTable("");
            
        }
        public static void GetCommand(int id)
        {
        }
    }
