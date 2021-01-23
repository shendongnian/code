    var groups = xDoc.Elements("Group")
                .Select(n => new
                {
                    GroupName = n.Get("GroupName", string.Empty),
                    GroupHeader = n.Get("GroupHeader", string.Empty),
                    TimeCreated = n.Get("TimeAdded", DateTime.MinValue),
                    Tags = n.Get("Tags", string.Empty),
                    Messages = n.GetEnumerable("GroupMessages/Message", m => new
                    {
                        Id = m.Get("MessageID", 0),
                        Message = m.Get("GroupMessage", string.Empty),
                        Group = m.Get("MessageGroup", string.Empty)
                    }).ToArray()
                })
                .ToList();
