    new object[]
    {
    dapuConfigs.Id,         //col0
    dapuConfigs.Description, //col1
    string.Join(",", dapuConfigs.CoveredLanes.Where(x => x.Id.Contains("FilterValue1")).ToArray()), //col2
    string.Join(",", dapuConfigs.CoveredLanes.Where(x => x.Id.Contains("FilterValue2")).ToArray()),//col3
    string.Join(",", dapuConfigs.CoveredLanes.Where(x => x.Id.Contains("FilterValue3")).ToArray()), //col4
    string.Join(",", dapuConfigs.CoveredLanes.Where(x => x.Id.Contains("FilterValue4")).ToArray()),//col5
    dapuConfigs.Position.Value, //col6
    dapuConfigs.Position.Value,//col7
    }
