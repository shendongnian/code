    var turd = new TurdCake();
    var poo = new PooCake();
    Console.WriteLine(
        "PooCake is{0} edible",
        poo.Edible ? string.Empty : " not");
    Console.WriteLine(
        "PooCake is{0} edible",
        (Cake)poo.Edible ? string.Empty : " not");
    Console.WriteLine(
        "TurdCake is{0} edible",
        turd.Edible ? string.Empty : " not");
    Console.WriteLine(
        "TurdCake is{0} edible",
        (Cake)turd.Edible ? string.Empty : " not");
    Console.ReadKey();
