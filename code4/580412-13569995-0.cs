     int number1 = 20;
     int number2 = 30;
     for (tempNum = 1; ; tempNum++)
     {
       if (tempNum % number1 == 0 && tempNum % number2 == 0)
       {
           Console.WriteLine("L.C.M is - ");
           Console.WriteLine(tempNum.ToString());
           Console.Read();
           break;
        }
     }
    // output -> L.C.M is - 60
