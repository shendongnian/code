	internal static class SqlConnectionExtension
	{
		private static readonly PropertyInfo _clientConnectionIdPropertyInfo = typeof(SqlConnection).GetProperty("ClientConnectionId");
		private static readonly HashSet<Guid> _clientConnectionIds = new HashSet<Guid>();
		
		/// <summary>
		/// Method that calls <see cref="SqlConnection.Open()"/>, measuring the time it takes.
		/// </summary>
		/// <param name="sqlConnection">The <see cref="SqlConnection"/> to open.</param>
		/// <param name="openTime">The total time that the call to <see cref="SqlConnection.Open()"/> took.</param>
		/// <returns>True if a login took place; false if a connection was returned from a connection pool.</returns>
		public static bool Login(this SqlConnection sqlConnection, out TimeSpan openTime)
		{
			Stopwatch loginTimer = Stopwatch.StartNew();
			sqlConnection.Open();
			loginTimer.Stop();
			openTime = loginTimer.Elapsed;
		#if NET_4_0_3
			Guid clientConnectionId = sqlConnection.ClientConnectionId;
		#else
			Guid clientConnectionId = Guid.Empty;
			if (_clientConnectionIdPropertyInfo != null)
			{
				clientConnectionId = (Guid)_clientConnectionIdPropertyInfo.GetValue(sqlConnection, null);
			}
		#endif
			if (clientConnectionId != Guid.Empty && !_clientConnectionIds.Contains(clientConnectionId))
			{
				lock (_clientConnectionIds)
				{
					if (_clientConnectionIds.Add(clientConnectionId))
					{
						return true;
					}
				}
			}
			return false;
		}
	}
