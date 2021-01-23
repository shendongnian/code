        public dynamic ReturnSomeData()
        {
            return context.Documents.Select(d => new
            {
                Id = d.Id,
                UserId = d.UserId
            });
        }
