                public static int Width = 750;
                public static int Height = 750;
    ...
                    int N = 500;
                    int Threads = 11;
                    Images = new Emgu.CV.Image<Rgb, float>[N];
                    Console.WriteLine("Start");
                    ParallelOptions po = new ParallelOptions();
                    po.MaxDegreeOfParallelism = Threads;
                    for (int i = 0; i < N; i++)
                    {
                        Images[i] = GetRandomImage();
                    }
                    System.Threading.Tasks.Parallel.For(0, N, po, new Action<int>((i) =>
                    {
                        //Console.WriteLine("CallingSmooth");
                        Images[i].SmoothBilatral(15, 50, 50);
                        //Console.WriteLine("SmoothCompleted");
                    }));
                    Console.WriteLine("End");
