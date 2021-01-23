    public override void Up()
            {
               
                RenameColumn("dbo.atable","oldname","newname");
                AddColumn("dbo.anothertable", "columname", c => c.String(maxLength: 250));
               
            }
