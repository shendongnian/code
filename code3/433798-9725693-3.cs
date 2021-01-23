            List<double> firstList = new List<double>() { 15, 36, -7, 12, 8 };
            // the following section could be refactored further by putting the classes
            // in a list of IMyList and then looping through it
            var rat = new Ratio();
            rat.SetList(firstList);
            while (!rat.IsDone())
            {
                double op1 = rat.GetOperand1();
                double op2 = rat.GetOperand2();
                rat.SetResult(rat.Calculate(op1, op2);
                rat.Next();
            }
            var results = rat.GetResults();
