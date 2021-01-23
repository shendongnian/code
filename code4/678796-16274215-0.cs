    static bool Find(List c, Coffee x)
    {
        bool result = false; 
        foreach(Coffee coffee in c)
        {
            result = coffee.CoffeeIsSame(x); 
            if (result) 
            {
                 break;
            }
        }
        return result;
    }
