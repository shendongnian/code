    public static class StringEx
    {
        public static async Task<string> JoinAsync<T>(string separator, IAsyncEnumerable<T> seq)
        {
            if (seq == null)
                throw new ArgumentNullException(nameof(seq));
            await using (var en = seq.GetAsyncEnumerator())
            {
                if (!await en.MoveNextAsync())
                    return string.Empty;
                string firstString = en.Current?.ToString();
                if (!await en.MoveNextAsync())
                    return firstString ?? string.Empty;
                // Null separator and values are handled by the StringBuilder
                var sb = new StringBuilder(256);
                sb.Append(firstString);
                do
                {
                    var currentValue = en.Current;
                    sb.Append(separator);
                    if (currentValue != null)
                        sb.Append(currentValue);
                }
                while (await en.MoveNextAsync());
                return sb.ToString();
            }
        }
    }
