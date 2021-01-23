    public OtherDataMap()
    {
       Id(x => x.MasterDataID, "MasterDataID")
          .GeneratedBy.Foreign("MasterData")
       Map(x => x.OtherName).Column("OtherName"); // change from x.Name
       HasOne(x => x.MasterData);
    }
