    public class FileEx
    {
        public static async void CopyWaitAsync(string src, string dst, int timeout, Action doWhenDone)
        {
            while (timeout > 0)
            {
                try
                {
                    File.Copy(src, dst);
                    doWhenDone();
                    break;
                }
                catch (IOException) { }
                await Task.Delay(100);
                timeout -= 100;
            }
        }
        public static async Task<string> ReadAllTextWaitAsync(string filePath, int timeout)
        {
            while (timeout > 0)
            {
                try {
                    return File.ReadAllText(filePath);
                }
                catch (IOException) { }
                await Task.Delay(100);
                timeout -= 100;
            }
            return "";
        }
        public static async void WriteAllTextWaitAsync(string filePath, string contents, int timeout)
        {
            while (timeout > 0)
            {
                try
                {
                    File.WriteAllText(filePath, contents);
                    return;
                }
                catch (IOException) { }
                await Task.Delay(100);
                timeout -= 100;
            }
        }
    }
