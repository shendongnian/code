    public static class AdministratorExtensions
    {
        public static void log( this Administrator admin, bool success ) { ... }
    }
----------
    var admin = new Administrator();
    admin.Log( true );
