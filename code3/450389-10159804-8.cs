    while (input != null)
        {
            string[] splitInput = inputLine.Split();
            EmpNum = int.Parse(splitInput[0]);
            EmpName = (splitInput[1]);
            EmpAdd = (splitInput[2]);
            EmpWage = double.Parse(splitInput[3]);
            EmpHours = double.Parse(splitInput[4]);
            inputLine = (myFile.ReadLine());
            Console.WriteLine("test {0},{1},{2}", EmpNum, EmpWage, EmpHours);
        }
