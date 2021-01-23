    namespace app.Models
    {
        public class Conexion : DbContext
        {
            private static Conexion Instance = null;
            private Conexion(string con) : base(con) { }
            public static Conexion MainConexion 
            {
                get
                { //error here
                    if (Instance == null)
                    {
                        Instance = new Conexion(
                            @"Server=*****; User Id=***;Password=****; Database=****");
                    }
                    return Instance;
                }
            }
            public DbSet<label> Labels { get; set; }
            public DbSet<checke_status> CheckStatus { get; set; }
        }
    }
