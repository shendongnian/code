    static string Skrci(string stavek)
    {
        string[] p;
        p = stavek.Split(' ');  // polje separatov
        for (int i = 0; i < p.Length; i++)
        {
            if (p[i].Length > 0)
            {
                char zacetnica = Char.ToUpper(p[i][0]);
                p[i] = p[i].Remove(0, 1);
                p[i] = p[i].Insert(0, zacetnica.ToString());
            }
        }
        return string.Join(" ", p);
    }
    static void Main(string[] args)
    {
        string[] p = null;
        Console.Write("Vpiši nek stavek: ");
        string stavek = Console.ReadLine();
        stavek = Skrci(stavek);
        Console.WriteLine(stavek);
        Console.ReadKey(true);
    }
