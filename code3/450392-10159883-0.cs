    string[] splitInput = inputLine.Split();
    if (splitInput.Length >= 5) {
      EmpNum = int.Parse(splitInput[0]);
      EmpName = (splitInput[1]);
      EmpAdd = (splitInput[2]);
      EmpWage = double.Parse(splitInput[3]);
      EmpHours = double.Parse(splitInput[4]);
    } else {
      // not enough items - show an error message or something
    }
