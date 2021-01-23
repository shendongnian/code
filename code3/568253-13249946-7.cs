    public MasterDataMap()
    {
       Id(x => x.MasterDataID).Column("MasterDataID")
         .GeneratedBy.gui.Sequence("MASTER_DATA_SEQ");
       Map(x => x.Name).Column("Name");
       HasOne(x => x.OtherData);
    }
