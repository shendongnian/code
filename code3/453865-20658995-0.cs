        private async Task<int> ComputeFibAsync(int n)
        {
            return await Task.Run(
                async () =>
                {
                    if (n < 2)
                    {
                        return 1;
                    }
                    else
                    {
                        var result = await Task.WhenAll<int>(ComputeFibAsync(n - 1), ComputeFibAsync(n - 2));
                        return result[0] + result[1];
                    }
                }
                );
        }
