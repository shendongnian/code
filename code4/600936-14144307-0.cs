        class MyEntity {
            public Guid EntityId { get; set; }
            public MyEntity() {
                EntityId = Guid.NewGuid();
            }
        }
