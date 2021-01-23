    List<DtuSensorConfig> dSensorConf = new List<DtuSensorConfig>()
    foreach (DataGridViewRow dr in dataGridView3.Rows)
    {
        //Create a CoveredTrafficLane list 
        List<CoveredTrafficLane> covTrafLane = new List<CoveredTrafficLane>();
        foreach(DataGridViewColumn col in dr.Columns) //DGV COl 2,3,4,5
        {
            covTrafLane.Add(New CoveredTrafficLane(col.Value.ToString()));
        }
        //Create RseDevicePosition
        RseDevicePosition devPos;
        int ctx = 0;
        Int32.TryParse(dr.Cells["dtux"].Value.ToString(), out ctx);
        int cty = 0;
        Int32.TryParse(dr.Cells["dtuy"].Value.ToString(), out cty);
        int ctz = 0;
        Int32.TryParse(dr.Cells["dtuz"].Value.ToString(), out ctz);
        int dtuazu = 0;
        Int32.TryParse(dr.Cells["dtuazim"].Value.ToString(), out dtuazu);
        int dtuele = 0;
        Int32.TryParse(dr.Cells["dtuele"].Value.ToString(), out dtuele);
        int dtuti = 0;
        Int32.TryParse(dr.Cells["dtutilt"].Value.ToString(), out dtuti);
    
        devPos = new RseDevicePosition(
        new ValueWithUnit<int>(ctx, "mm"),
        new ValueWithUnit<int>(cty, "mm"),
        new ValueWithUnit<int>(ctz, "mm"),
        new ValueWithUnit<int>(dtuazu, "tenthOfDegree"),
        new ValueWithUnit<int>(dtuele, "tenthOfDegree"),
        new ValueWithUnit<int>(dtuti, "tenthOfDegree"));
    
        //here create a DtuSensorConfig
        dSensorConf.Add(
            new DtuSensorConfig(dr.Cells["DGVCOL0"].Value.Tostring(), //DGV COl0
                                dr.Cells["DGVCOL1"].Value.Tostring(), //DGV COl1       
                                covTrafLane,
                                devPos));
    }
    VisConfig vConf = new VisConfig(string.Empty,
                                    string.Empty,
                                    dSensorConf); // 
