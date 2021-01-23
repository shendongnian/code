        public async static Task<List<uspGetEmployees_Result>> GetEmployess(int professionalID, int startIndex, int pageSize, string where, string equals)
        {
            var httpCurrent = HttpContext.Current;
            // Most of these operations are unlikely to be time-consuming,
            // so why await the whole thing?
            using (AFCCInc_ComEntities db = new AFCCInc_ComEntities())
            {
                // I don't really know what exactly uspGetEmployees returns
                // and, if it's an IEnumerable, whether it yields its elements lazily.
                // The fact that it can be null, however, bothers me, so I'll sidestep it.
                List<uspGetEmployees_Result> emps = await Task.Run(() =>
                    (db.uspGetEmployees(professionalID, startIndex, pageSize, where, equals) ?? Enumerable.Empty<uspGetEmployees_Result>()).ToList()
                );
                if (emps.Count == 0)
                {
                    return null;
                }
                // I'm assuming that BuildUserFilePath returns string - no async.
                await Task.Run(() =>
                {
                    Parallel.ForEach(emps, e =>
                    {
                        // NO async/await within the ForEach delegate body.
                        e.Avatar = BuildUserFilePath(e.Avatar, e.UserId, httpCurrent, true);
                    });
                });
            }
        }
