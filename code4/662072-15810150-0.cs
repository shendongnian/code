    public class ddMenuHandler
    {
        ddMenuAccess menuaccess = null;
        public ddMenuHandler()
        {
            this.menuaccess = new ddMenuAccess();
        }
        public DataSet dsCwkrCaseEditing(int cwID)
        {
            return menuaccess.CwkrsCaseEditing(cwID);
        }
}
