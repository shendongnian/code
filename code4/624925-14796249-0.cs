    ...
           public byte[] TimeStamp { get; set; }
        }
        
         public class UserModelConfiguration: EntityTypeConfiguration<User> {
                public UserModelConfiguration() {
                    Property(p => p.TimeStamp).IsRowVersion();            
                }
            }
