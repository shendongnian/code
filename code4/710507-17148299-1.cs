            //WARM UP:
            widgets.Where(a => a.Name.StartsWith("4")).Count();
            foreach (Widget w in widgets)
            {
                if (w.Name.StartsWith("4"))
                    found += 1;
            }
            //RUN Test
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
  
            found = widgets.Where(a => a.Name.StartsWith("4")).Count();
            stopwatch1.Stop();
            Console.WriteLine(found + " - " + stopwatch1.Elapsed);
           
            found = 0;
            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            foreach (Widget w in widgets)
            {
                if (w.Name.StartsWith("4"))
                    found += 1;
            }
            stopwatch2.Stop();
            Console.WriteLine(found + " - " + stopwatch2.Elapsed);
