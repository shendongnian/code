    DateTime now1 = DateTime.Now;
    string strDate = now1.ToBinary().ToString();
    DateTime now2 = DateTime.FromBinary(long.Parse(strDate));
    Console.WriteLine(now1.ToBinary());
    Console.WriteLine(now2.ToBinary());
