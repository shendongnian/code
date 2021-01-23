    public static class HardCodedRoles
    {
        public const string Managers = "Managers";
        public const string Administrators = "Administrators";
    }
    [RequiresRole(HardCodedRoles.Managers)] 
    
