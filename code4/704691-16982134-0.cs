            var myParams = Tuple.Create(100, "Hello, world!");
            var worker = new BackgroundWorker();
            worker.DoWork += (sender, args) =>
            {
                var arg = (Tuple<int, string>)args.Argument;
                if (arg.Item2.Length > 5)
                {
                    var foo = arg.Item1 + 200;
                }
                // etc ...
            };
            worker.RunWorkerAsync(myParams);
