    private static async Task<IEnumerable<string>>
        FileReadAllLinesAsync(string path, Label label)
    {
        int completeCount = 0;
        int incompleteCount = 0;
        using (var reader = new StreamReader(path))
        {
            while (true)
            {
                var task = reader.ReadLineAsync();
                if (task.IsCompleted)
                {
                    completeCount++;
                }
                else
                {
                    incompleteCount++;
                }
                if (await task == null)
                {
                    break;
                }
                label.Text = string.Format("{0} / {1}",
                                           completeCount,
                                           incompleteCount);
            }
        }
        return null;
    }
