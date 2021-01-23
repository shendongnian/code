                try
                {
                    response = (SearchResponse)con.SendRequest(request);
                    return response.Entries.Cast<SearchResultEntry>()
                        .Select(entry => entry.Attributes)
                        .Select(x => GetADUserSearchItemFromADProperties(x, logMessage))
                        .Where(user => user.HasName)
                        .Cast<IUserSearchItem>();
                }
                catch (DirectoryOperationException ex)
                {
                    response = (SearchResponse) ex.Response;
                    return response.Entries.Cast<SearchResultEntry>()
                        .Select(entry => entry.Attributes)
                        .Select(x => GetADUserSearchItemFromADProperties(x, logMessage))
                        .Where(user => user.HasName)
                        .Cast<IUserSearchItem>();
                }
