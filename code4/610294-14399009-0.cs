    int a = 2, b = 3;
            double c = 2.345, d = 3.45;
            object inta = a, intb = b;
            object doublec = c, doubled = d;
            Console.WriteLine(Sum(inta, intb).ToString());
            Console.WriteLine(Sum(doublec, doubled).ToString());
    public object Sum(object a, object b)
        {
            object sum = null;
            if (a.GetType().ToString() == "System.Int32" && b.GetType().ToString() == "System.Int32")
            {
                sum = Convert.ToInt32(a.ToString()) + Convert.ToInt32(b.ToString());
            }
            if (a.GetType().ToString() == "System.Double" && b.GetType().ToString() == "System.Double")
            {
                sum = Convert.ToDouble(a.ToString()) + Convert.ToDouble(b.ToString());
            }
            return sum;
                
        }
