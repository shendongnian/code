    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    public abstract class ExtendedDbMigration : DbMigration
    {
        public void DoCommonTask(string parameter)
        {
            Sql("** DO SOMETHING HERE **");
        }
    
        public void UndoCommonTask(string parameter)
        {
            Sql("** DO SOMETHING HERE **");
        }
    }
