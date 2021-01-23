    static void GetHaendler()
    {
        using (var riaService = new gkmRia())
        {
            var hladany = "someone";
            var haendlers = from hndlr in riaService.GetGkmHaendlerOutlet().AsEnumerable()
                            where hndlr.NameOutlet.NoWhiteSpaces() == hladany.NoWhiteSpaces()
                            select hndlr;
            Console.Write(haendlers.First().NameOutlet);
        }
    }
