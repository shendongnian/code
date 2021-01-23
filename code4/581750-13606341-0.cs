    foreach (var g in groups) {
        Console.WriteLine("Case ID:{0}", g.Key);
        foreach (var element in g) {
            Console.WriteLine("Approver ID:{0}", element.ApproverId);
        }
    }
