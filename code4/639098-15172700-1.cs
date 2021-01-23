    [STAThread]
    static void Main(string[] args)
    {
        Clipboard.SetText("boo yah!", TextDataFormat.Html);
        Class1 aas = new Class1();
        string a = aas.SwapClipboardHtmlText("chetan");
        Console.WriteLine(a);
        Console.WriteLine(Clipboard.GetText(TextDataFormat.Html));
        Console.ReadLine();
    }
