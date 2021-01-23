    testDsrcConfigs.Add(
                         new SdrcConfig(
                             dr.Cells["bid"].Value.ToString(), 
                             dr.Cells["bdesc"].Value.ToString(),        
                             covTrafLane,
                             devPos, devnum,
                             ((MyConfig.
        .ObuTransactionSystemConfig as DsrcTransactionSystemConfig).
             DsrcSystemConfig as MultiLaneDsrcSystemConfig).DsrcConfigs[0].Settings);
