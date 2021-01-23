    namespace dbfirstjointable.Models
    {
        using System;
        using System.Collections.Generic;
        
        public partial class Task
        {
            public Task()
            {
                this.Users = new HashSet<User>();
            }
        
            public int Id { get; set; }
            public string Name { get; set; }
        
            public virtual ICollection<User> Users { get; set; }
        }
    }
    namespace dbfirstjointable.Models
    {
        using System;
        using System.Collections.Generic;
        
        public partial class User
        {
            public User()
            {
                this.Tasks = new HashSet<Task>();
            }
        
            public int Id { get; set; }
            public string Name { get; set; }
        
            public virtual ICollection<Task> Tasks { get; set; }
        }
    }
