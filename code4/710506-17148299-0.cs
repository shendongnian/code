            //WARM UP:
            widgets.Where(a => a.Name.StartsWith("4")).Count();
            foreach (Widget w in widgets)
            {
                if (w.Name.StartsWith("4"))
                    found += 1;
            }
            //RUN Test
            DateTime starttime = DateTime.Now;
  
            found = widgets.Where(a => a.Name.StartsWith("4")).Count();
            Console.WriteLine(found + " - " + DateTime.Now.Subtract(starttime).Milliseconds + " ms");
            starttime = DateTime.Now;
            found = 0;
            foreach (Widget w in widgets)
            {
                if (w.Name.StartsWith("4"))
                    found += 1;
            }
            Console.WriteLine(found + " - " + DateTime.Now.Subtract(starttime).Milliseconds + " ms");
