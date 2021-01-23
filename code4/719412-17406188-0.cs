    static void Main(string[] args) {
        try
        {
            SetPlayers();
            WriteCards();
            SeeWhoWins();
            Winner();
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
