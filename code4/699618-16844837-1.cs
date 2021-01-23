    using System;
    using System.Threading;
    namespace Demo
    {
        // This represents the interface to the scanner hardware.
        sealed class BarcodeScannerDevice
        {
            int counter;
            public bool IsConnected()
            {
                return (++counter%4) != 0;  // Make it change every 4 calls.
            }
        }
        // This class has the responsibility of polling the scanner device to determine its status.
        sealed class BarcodeScannerMonitor
        {
            readonly Timer timer;
            readonly BarcodeScannerDevice scanner;
            bool isConnected;
            public BarcodeScannerMonitor(BarcodeScannerDevice scanner)
            {
                this.scanner = scanner;
                timer = new Timer(poll, null, Timeout.Infinite, Timeout.Infinite);
            }
            public bool IsConnected
            {
                get
                {
                    return isConnected;
                }
            }
            public void StopPolling()
            {
                timer.Change(Timeout.Infinite, Timeout.Infinite);
            }
            public void StartPolling(TimeSpan pollingInterval)
            {
                timer.Change(TimeSpan.Zero, pollingInterval);
            }
            void poll(object state)
            {
                isConnected = scanner.IsConnected();
            }
        }
        static class BarcodeScannerMonitorFactory
        {
            // You probably want to encapsulate this kind of coupling and 
            // keep it away from the UI, so we use a factory.
            public static BarcodeScannerMonitor Create()
            {
                var scanner = new BarcodeScannerDevice();
                return new BarcodeScannerMonitor(scanner);
            }
        }
        class Program
        {
            void run()
            {
                var scannerStatus = BarcodeScannerMonitorFactory.Create();
                scannerStatus.StartPolling(TimeSpan.FromSeconds(1));
                while (true)
                {
                    Console.WriteLine("Scanner is " + (scannerStatus.IsConnected ? "connected" : "disconnected"));
                    Thread.Sleep(500);
                }
            }
            static void Main()
            {
                new Program().run();
            }
        }
    }
