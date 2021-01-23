    shortUrlIndexCollection.FindAndModify(
                    Query.Or(
                        Query.And(Query.EQ("_id", "Index"), Query.EQ("LockId", Guid.Empty)), Query.LT("UnlockOn", now)),
                    SortBy.Null,
                    Update.Set("LockId", guid).Set("UnlockOn", now + reserveDuration),
                    true);
