    using TwistedOak.Collections;
    using TwistedOak.Util;
    static void Main() {
        var p = new PerishableCollection<PerishableCollection<string>>();
        var f = p.Flattened(Lifetime.Immortal);
        f.CurrentAndFutureItems().Subscribe(e => {
            Console.WriteLine("{0} added to flattened", e.Value);
            e.Lifetime.WhenDead(() => Console.WriteLine("{0} removed from flattened", e.Value));
        });
        // add some 'c' items to f via p
        var c = new PerishableCollection<string>();
        var cLife = new LifetimeSource();
        c.Add("candy", Lifetime.Immortal);
        p.Add(c, cLife.Lifetime);
        c.Add("cane", Lifetime.Immortal);
        // add some 'd' items to f via p
        var d = new PerishableCollection<string>();
        p.Add(d, Lifetime.Immortal);
        d.Add("door", Lifetime.Immortal);
        d.Add("dock", Lifetime.Immortal);
            
        // should remove c's items from f via removing c from p
        cLife.EndLifetime();
    }
