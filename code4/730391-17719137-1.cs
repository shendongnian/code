    context.Record.AddOrUpdate(c => c.RecordName, new Record()
                {
                    RecordName = "New Record",
                    Created = DateTime.UtcNow,
                    Updated = DateTime.UtcNow,
                 })
