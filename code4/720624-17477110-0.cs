    currSession.Save(ProgramObject.factPowerCommisioning);
    currSession.Save(ProgramObject.planPowerCommisioning);
    // or
    References(x => x.factPowerCommisioning).Column("factCommisioningID").Cascade.All();
    References(x => x.planPowerCommisioning).Column("planCommisioningID").Cascade.All();
