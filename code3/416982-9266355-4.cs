    string originalValue = "Hello, World!";
    string workingCopy = originalValue;
    workingCopy = workingCopy.Substring(0, workingCopy.Length - 1);
    workingCopy = workingCopy + "?";
    Console.WriteLine(originalValue.Equals("Hello, World!"); // writes "True"
    Console.WriteLine(originalValue.Equals(workingCopy); // writes "False"
