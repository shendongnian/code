    static void calcTotal(double[] numbers, ref double total)
    {
        int sub = 0;
        while (sub < numbers.Length)
        {
                total = numbers[sub] + total;
                sub++;     //IT MUST BE HERE
        }  
        //sub++;           //NOT HERE
    }
