csharp
class Program
{
    const int STD_INPUT_HANDLE = -10;
    [DllImport("kernel32.dll", SetLastError = true)]
    internal static extern IntPtr GetStdHandle(int nStdHandle);
    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool CancelIoEx(IntPtr handle, IntPtr lpOverlapped);
    static void Main(string[] args)
    {
        // Start the timeout
        var read = false;
        Task.Delay(10000).ContinueWith(_ =>
        {
            if (!read)
            {
                // Timeout => cancel the console read
                var handle = GetStdHandle(STD_INPUT_HANDLE);
                CancelIoEx(handle, IntPtr.Zero);
            }
        });
        try
        {
            // Start reading from the console
            Console.WriteLine("Do you want to continue [Y/n] (10 seconds remaining):");
            var key = Console.ReadKey();
            read = true;
            Console.WriteLine("Key read");
        }
        // Handle the exception when the operation is canceled
        catch (InvalidOperationException)
        {
            Console.WriteLine("Operation canceled");
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Operation canceled");
        }
    }
}
