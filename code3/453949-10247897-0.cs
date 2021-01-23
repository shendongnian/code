            public Ticket
            {
                public int Id { get; set; }
                public int OwnerId{ get; set; }
                public int DependencyId { get; set; }
                public string SerialNumber { get; set; }
            
                public Owner Owner { get; set; } 
                public Dependency Dependency { get; set; }
            }
            
            public Owner 
            {
                public int Id { get; set; }
                public string Name { get; set; }
                public List<Ticket> Tickets {get;set;}
            }
            
            public Dependency 
            {
                public int Id { get; set; }
                public string Name { get; set; }
                public List<Ticket> Tickets {get;set;}
            }
            public List<Ticket> SelectTickets(string serialNumber, int ownerId, int dependencyId)
            {
                return context.Tickets.Where(t => t.SerialNumber == serialNumber && t.OwnerId == ownerId && t.DependencyId == dependencyId).ToList();
            }
