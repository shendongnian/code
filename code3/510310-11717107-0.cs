    [XMLArray("Users")]
    public class User
    {
        [XMLAttribute("copy")]
        public bool? copy
        {
            get
            {
                return (copy.HasValue) ? copy : null;
            }
        }
    }
