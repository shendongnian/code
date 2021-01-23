    namespace StartReg.Migrations {
        using System;
        using System.Data.Entity;
        using System.Data.Entity.Migrations;
        using System.Linq;
        using StartReg.Data;
    
        internal sealed class Configuration : DbMigrationsConfiguration<StartReg.Data.StartRegDb> {
            public Configuration() {
                AutomaticMigrationsEnabled = false;
            }
    
            protected override void Seed(StartReg.Data.StartRegDb context) {
                //  This method will be called after migrating to the latest version.
            }
        }
    }
