    public class Status
    {
        public string Value { get; set; }
        //public Status() { }
        public Status(string l)
        {
            switch (l.ToUpper())
            {
                case "A":
                    Value = "Yes";
                    break;
                case "B":
                    Value = "No";
                    break;
                case "C":
                    Value = "Okay";
                    break;
                case "D":
                    Value = "Maybe";
                    break;
                case "E":
                    Value = "Need More Info";
                    break;
                default:
                    Value = "Unknown";
                    break;
            }
        }
    }
