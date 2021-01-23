    private IEnumerable<string> GetNicknamesFromCache()
        {
            const String cacheValueName = "Nicknames";
            var result = HttpRuntime.Cache.Get(cacheValueName) as List<String>;
            if (result == null)
            {
                result = _repository.GetAllNicknames();
                using (var connection = new SqlConnection(_config.ConnectionString))
                {
                    connection.Open();
                    SqlDependency.Start(_config.ConnectionString);
                    var command = new SqlCommand("SELECT Nickname FROM dbo.[User]", connection);
                    var dependency = new SqlCacheDependency(command);
                    HttpRuntime.Cache.Insert(cacheValueName, result, dependency);
                    command.ExecuteNonQuery();
                }
            }
            return result;
        }
