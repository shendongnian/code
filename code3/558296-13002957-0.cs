    public class Capture {
        /// <summary>
        /// Get and Set Capture's Unique Identifier.
        /// </summary>
        public int Id { get; set; }
            
        /// <summary>
        /// Get and Set Capture's Operating System.
        /// </summary>
        public virtual OperatingSystem OperatingSystem { get; set; }
    }
    
    public class OperatingSystem {
        /// <summary>
        /// Operating System's Unique Identifier.
        /// </summary>
        public int Id { get; set; }
    }
