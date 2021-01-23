var groupedData = Data.GroupBy(x => x.Period).Select(x => x).ToList();
foreach (var group in groupedData) {
    var gr = group.FirstOrDefault();
    Console.WriteLine("Period: {0}", gr.Period);
    Console.WriteLine("Adjustment: {0}", gr.Adjustment);
}
