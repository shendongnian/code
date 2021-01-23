        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static int UpdateItem(EmployeeItem myItem)
        {
            return EmployeeDB.UpdateItem(myItem);
        }
    
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool DeleteItem(EmployeeItem myItem)
        {
            return EmployeeDB.DeleteItem(myItem.EmployeeID);
        }
