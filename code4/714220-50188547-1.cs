            public static void Handle(Command command)
            {
                switch (command)
                {
                    case var c when c.IsFirstCommand:
                        var data = Extentions.getFromUnion<FirstCommand>(change);
                        // Handler for case
                        break;
                    case var c when c.IsSecondCommand:
                        var data2 = Extentions.getFromUnion2<SecondCommand, int>(change);
                        // Handler for case
                        break;
                }
            }
            
