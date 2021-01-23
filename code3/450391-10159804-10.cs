    inputLine = (myFile.ReadLine());
    string[] splitInput = inputLine.Split();
    if(splitInput!=null && splitInput.length ==5)
    {
     EmpNum = int.Parse(splitInput[0]);
            EmpName = (splitInput[1]);
            EmpAdd = (splitInput[2]);
            EmpWage = double.Parse(splitInput[3]);
            EmpHours = double.Parse(splitInput[4]);
            Console.WriteLine("test {0},{1},{2}", EmpNum, EmpWage, EmpHours);
    }
