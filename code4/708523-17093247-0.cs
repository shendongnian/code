    if (args.Length > 0)
            {
                runTestCases.RunTestCaseForSelectedField(args[0]);
            }
            else
            {
                //runTestCases.RunTestCaseForAllFields();
                Console.WriteLine("No Parameter");
            }
