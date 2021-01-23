            DateTime StartTime = DateTime.Parse("3:0:0");//If pm it should be 15
            DateTime EndTime = DateTime.Parse("6:0:0");//If pm it should be 18
            while (StartTime!=EndTime)
            {
                double minuts = +45;
                StartTime = StartTime.AddMinutes(minuts);
            }
