    List<Test>laneConfigs = new List<Test>();//From a class
                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    int bbbBorder = 0;
                    Int32.TryParse(dr.Cells["BBor"].Value.ToString(), out bbbBorder );
                    int eeee= 0;
                    Int32.TryParse(dr.Cells["EBor"].Value.ToString(), out eee);
    
                    LaneConfig laneConfig = new LaneConfig(
                        dr.Cells["ID"].Value.ToString(),
                        (TrafficLaneType)Enum.Parse(typeof(TrafficLaneType), dr.Cells["Type"].Value.ToString()),
                        new ValueWithUnit<int>(bbbBorder, "mm"),
                        new ValueWithUnit<int>(eee, "mm"));
    
                    laneConfigs.Add(llaneConfig);
                }
