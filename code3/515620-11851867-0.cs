            var questions = questionService.Details(pk, rk);
            var topics = contentService.GetTitles("0006000")
                            .Where(x => x.RowKey.Substring(2, 2) != "00");
            var types = referenceService.Get("07");
            model = (from q in questions
                join t in topics on q.RowKey.Substring(0, 4) equals t.RowKey into topics2
                from t in topics2.DefaultIfEmpty())
                select new Question.Grid {
                    PartitionKey = q.PartitionKey,
                    RowKey = q.RowKey,
                    Topic = t == null ? "No matching topic" : t.Title,
                    ...
                }).Union
                (from a in types
                 join q in questions on q.type equals a.RowKey 
                 where a.ID != null
                 select new Question.Grid {
                        PartitionKey = q.PartitionKey,
                        RowKey = q.RowKey,
                        Topic = t == null ? "No matching topic" : t.Title,
                        ...
                })
                
