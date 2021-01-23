                // warming up
                var visitor = new MyVisitor(1);
                var expr = MakeWhereForPK(0);
                visitor.ReplaceId(MakeWhereForPK(0));
                var sw = new System.Diagnostics.Stopwatch();
                sw.Start();
                for (var i = 0; i < 1000000; i++)
                {
                    MakeWhereForPK(i);
                }
                sw.Stop();
                Console.WriteLine("Make expression: {0}", sw.Elapsed);
                sw.Restart();
                for (var i = 0; i < 1000000; i++)
                {
                    visitor.Visit(expr);
                }
                sw.Stop();
                Console.WriteLine("Replace constant expression: {0}", sw.Elapsed);
                Console.WriteLine("Done.");    
