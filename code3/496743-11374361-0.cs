    public class ClassName
    {
        private readonly string[] PMCTableColumnNames = new string[] { "PMCIP", "Description", "Cam1ReferencePoints", "Cam2ReferencePoints", "DataserverIP" };
        private readonly string[] PMDTableColumnNames = new string[] { "PMDIP", "Description" };
        private readonly string[] PMDZonesTableColumnNames = new string[] { "PMDIP", "Description", "Zone" };
    
        private string[][] ArrayReferences;
        
        public ClassName()
        {
            ArrayReferences = new string[][] { PMCTableColumnNames, PMDTableColumnNames, PMDZonesTableColumnNames };
        }
        
        void SomeMethod()
        {
            string[] _PMDTableColumnNames = ArrayReferences[1];
        }
    }
