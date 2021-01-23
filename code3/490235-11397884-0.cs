    Component(x => x.Event, m =>
                {
                    m.Map(x => x.ID).Column("EventID");
                    m.Map(x => x.Name).Column("EventName");
                    m.Map(x => x.Description).Column("EventDescription");
                });
