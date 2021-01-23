    dynamic test = new ExpandoObject(); 
    //reference the object as a dictionary
    var asDictinary = test as IDictionary<string, Object>;
 
    //Test by setting it as property and get as a dictionary
    test.testObject = 123;
    Console.Write("Testing it by getting the value as if it was a dictionary");
    Console.WriteLine(asDictinary["testObject"]);
    //Test by setting as dictionary and get as a property
    //NOTE: the command line input should be "input", or it will fail with an error
    Console.Write("Enter the varible name, ");
    Console.Write("note that for the example to work it should the word 'input':");
    string variableName = Console.ReadLine();
    Console.Write("Enter the varible value, it should be an integer: ");           
    int variableValue = int.Parse(Console.ReadLine());
    asDictinary.Add(variableName, variableValue);
    Console.WriteLine(test.input);//Provided that the command line input was "input"
