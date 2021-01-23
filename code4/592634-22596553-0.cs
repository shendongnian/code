    public async Task Subscribe(IEnumerable<string> groups)
        {
            foreach(var group in groups)
            {
                await Groups.Add(Context.ConnectionId, group);
            }
        }
