    public async Task<bool> IsOnline()
		{
			using (var service = new DebugService())
			{
				return await service.OnlineCheckAsync();
			}
		}
