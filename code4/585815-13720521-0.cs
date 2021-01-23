    public static IAsyncOperation<IList<string>> DownloadAsStringsAsync(string id)
            {
                return Task.Run<Type retourned>(async () =>
                {
                    var data = await AsyncMethod(...);
                    return (somethingOfTypeRetourned;
                }).AsAsyncOperation();
            }
