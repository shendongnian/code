    Console.WriteLine((new TypeConverterChecker<Int16, Decimal>(0)).CanConvert); //True
    Console.WriteLine((new TypeConverterChecker<UInt16, Decimal>(0)).CanConvert); //True
    Console.WriteLine((new TypeConverterChecker<UInt16, Int64>(0)).CanConvert); //True
    Console.WriteLine((new TypeConverterChecker<UInt16, Double>(0)).CanConvert); //True
    Console.WriteLine((new TypeConverterChecker<UInt16, String>(0)).CanConvert); //False
