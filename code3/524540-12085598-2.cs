    static void Main()
    {
        string msg = @"<Data>
    <ItemIn date=""2012-08-09T10:25:54.06+01:00"" itemId=""000007721"" Id=""1"">   <Extensions><Info Id=""parts"" order=""issue""/></Extensions></ItemIn>
    </Data>";
        var obj = DeserializeXML<Data>(msg);
        Console.WriteLine(obj.ItemIn.Extensions.Info.order); // issue
    }
