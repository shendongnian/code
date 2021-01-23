    string[] printer = {"jupiter", "neptune", "pangea", "mercury", "sonic"};
    PrinterSetup(printer);
    // redefine PrinterSetup this way:
    public void PrinterSetup(string[] printer)
    {
        foreach (p in printer.Where(c => c == "jupiter"))
        {
            Process.Start("BLAH BLAH CODE TO ADD PRINTER VIA WINDOWS EXEC"");
        }
    }
