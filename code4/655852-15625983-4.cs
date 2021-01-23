    for (a = 2; a <= 100; a++)
    {
        for (i = 2; i < Math.Sqrt(a); i++) //<---
        {
            if (a % i == 0)
            {
                m = false;
                break; //<----
            }
        }
        if (m == true)
        {
            Console.WriteLine(a);
        }
        m = true; //<<******* Add this line
    }
