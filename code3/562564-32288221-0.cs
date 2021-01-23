    public override void Up()
            {
               
                RenameColumn("dbo.atable","odlanem","newname");
                AddColumn("dbo.anothertable", "columname", c => c.String(maxLength: 250));
               
            }
