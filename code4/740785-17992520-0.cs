    // This will call the implicit implementation
    var obj = new DatePrint(); // same as DatePrint obj = new DatePrint();
    obj.PrintDateTimeNow();
    // This will call the explicit implementation
    IPrint obj = new DatePrint();
    obj.PrintDateTimeNow();
