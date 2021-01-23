    ulong u = 0x780000105d0e0030;
    Console.WriteLine("Convert.ToInt64(\"0x780000105d0e0030\", 16) => {0}", Convert.ToInt64("0x780000105d0e0030", 16));
    Console.WriteLine("u                                         => {0}", u);
    Console.WriteLine("u.ToString(\"x\")                           => {0}", u.ToString("x"));
    Console.WriteLine("Convert.ToInt64(u.ToString(\"x\"), 16)      => {0}", Convert.ToInt64(u.ToString("x"), 16));
    Console.WriteLine("u = (ulong)Convert.ToInt64(\"0x780000105d0e0030\", 16)");
    u = (ulong)Convert.ToInt64("0x780000105d0e0030", 16);
    Console.WriteLine("u                                         => {0}", u);
