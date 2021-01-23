    var d1 = "آدنیس,اسم دختر,girl name,آدونیس--‌-گلی-به-رنگ-زرد-و-قرمز-که-فقط-هنگام-تابش-خورشید-باز-می-شود";
    var d2 = "آدنیس,اسم دختر,girl name,آدونیس---گلی-به-رنگ-زرد-و-قرمز-که-فقط-هنگام-تابش-خورشید-باز-می-شود";
    while (d.IndexOf("--", StringComparison.Ordinal) != -1) d1 = d1.Replace("--", "-");
    Console.WriteLine(d1); // the last characters are left 
    while (d2.IndexOf("--", StringComparison.Ordinal) != -1) d2 = d2.Replace("--", "-");
    Console.WriteLine(d2); // All clear 
