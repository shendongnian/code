            List<AlertInfo> alert = new List<AlertInfo>();
            alert.Add(new AlertInfo() { StratId = 1, GroupId = 1 });
            alert.Add(new AlertInfo() { StratId = 1, GroupId = 2 });
            alert.Add(new AlertInfo() { StratId = 1, GroupId = 3 });
            alert.Add(new AlertInfo() { StratId = 2, GroupId = 1 });
            alert.Add(new AlertInfo() { StratId = 2, GroupId = 2 });
            alert.Add(new AlertInfo() { StratId = 2, GroupId = 3 });
            alert.Add(new AlertInfo() { StratId = 3, GroupId = 1 });
            alert.Add(new AlertInfo() { StratId = 3, GroupId = 2 });
            //To know how much data will get stored
            var totalDataStore = alert.Select(x => x.StratId).Distinct().ToList();
            var result = alert.Where(x => x.StratId == 1).Select(x => new { Data1 = "Group" + x.StratId + x.GroupId }).Cast<dynamic>().Union(alert.Where(y => y.StratId == 2).Select(y => new { Data2 = "Group" + y.StratId + y.GroupId })).ToList();
        }
    }
    public class AlertInfo
    {
        public int StratId { get; set; }
        public int GroupId { get; set; }
    }
