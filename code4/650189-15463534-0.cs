    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    namespace StartReg.Data {        
        public class UserSession {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int UserSessionId { get; set; }
    
            [Required]
            [MaxLength(100)]
            public string UserId { get; set; }
    
            [ForeignKey("UserId")]
            public virtual User User { get; set; }
    
            [Required]
            public DateTimeOffset LogonTime { get; set; }
    
            [Required]
            [MaxLength(40)]
            public string LogonIPAddress { get; set; }
    
            [Required]
            [MaxLength()]
            public string LogonUserAgent { get; set; }
        }    
    }
