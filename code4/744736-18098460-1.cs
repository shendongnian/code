    var block = Expression.Block(
                    matchingMembers.Select(p =>       
                        Expression.Assign(
                            Expression.Property(instance2Parameter, p.Dest),
                            Expression.Property(instanceParameter, p.Source)))
