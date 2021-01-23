        private static async Task MethodAsync()
        {
            byte[] bytes = new byte[1024];
            var wr = new WeakReference(bytes);
            Console.WriteLine(wr.Target != null);
            await Task.Delay(100);
            FullGC();
            Console.WriteLine(wr.Target != null);
            await Task.Delay(100);
        }
        private static void FullGC()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
