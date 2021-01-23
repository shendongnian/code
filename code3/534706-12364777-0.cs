        string number = "2012001";
        int EmpNumber = 0;
        if (int.TryParse(number, out EmpNumber))
            Console.Write("Successful");
        string newNumber = EmpNumber.ToString("D8");
