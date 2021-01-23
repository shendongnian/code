    public void PrinterSetup(string[] printer)
    {
       if (printer.Contains("jupiter"))
       {
          Process.Start("BLAH BLAH CODE TO ADD PRINTER VIA WINDOWS EXEC");
       }
    }
    public static bool Contains<T>(this T[] thisArray, T searchElement)
    {
       return Array.Exists<T>(thisArray, x => x.Equals(searchElement));
    }
