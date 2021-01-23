    ((MyConfig.
            .ObuTransactionSystemConfig as DsrcTransactionSystemConfig).
                 DsrcSystemConfig as MultiLaneDsrcSystemConfig).DsrcConfigs.ForEach(
                     dsrcBeacon => testDsrcConfigs.Add(
                         new SdrcConfig(
                             dr.Cells["bid"].Value.ToString(), 
                             dr.Cells["bdesc"].Value.ToString(),        
                             covTrafLane,
                             devPos, devnum,
                             dsrcBeacon.Settings)));
