    DateTime? today = DateTime.Today;
    DateTime? yesterday = DateTime.Today.AddDays(-1);
    DateTime? nodate = null;
    DateTime? nodate2 = null;
    
    Console.WriteLine(today > yesterday); //true
    Console.WriteLine(today < yesterday); //false
    
    Console.WriteLine(today > nodate); //false
    Console.WriteLine(today == nodate); //false
    Console.WriteLine(today < nodate); //false
    
    Console.WriteLine(nodate > yesterday); //false
    Console.WriteLine(nodate == yesterday); //false
    Console.WriteLine(nodate < yesterday); //false
    
    Console.WriteLine(nodate > nodate2); //false
    Console.WriteLine(nodate == nodate2); //true - this is the exception
    Console.WriteLine(nodate < nodate2); //false
