    int a = 7;
    int b = 8;
    string formula = "a+b";
    formula=formula.Replace("a",a.ToString()).Replace("b",b.ToString());
    var calc = new System.Data.DataTable();
    Console.WriteLine(calc.Compute(formula, ""));
