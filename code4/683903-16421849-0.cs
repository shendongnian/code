    private static void FillCombo(ComboBox box)
            {
                List<DisplayableStatus> ds = new List<DisplayableStatus>();
                foreach (var val in Enum.GetValues(typeof(Status)))
                    ds.Add(new DisplayableStatus { Status = (Status)val, DisplayText = val.ToString() + " Nice" });
    
                box.DataSource = ds;
                box.DisplayMember = "DisplayText";
                box.ValueMember = "Status";
    
                box.SelectedValue = Status.Stop;
            }
    
            public enum Status
            {
                Unknown,
                Start,
                Stop
            }
    
            public class DisplayableStatus
            {
                public Status Status { get; set; }
                public string DisplayText { get; set; }
            }
