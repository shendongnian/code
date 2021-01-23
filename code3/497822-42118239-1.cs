     string[] originalStringArray = new string[] { "1", "2", "3", "5", "6" };
     int firstElementZero = 0;
     int insertAtPositionZeroBased = 3;
     string stringToPrepend = "0";
     string stringToInsert = "FOUR"; // Deliberate !!!
     originalStringArray = new List<string> { stringToPrepend }
                    .Concat(originalStringArray.ToList()).ToArray();
     insertAtPositionZeroBased += 1; // BECAUSE we prepended !!
     originalStringArray = new ArraySegment<string>(originalStringArray, firstElementZero, insertAtPositionZeroBased)       
                    .Concat(new string[] { stringToInsert })
                    .Concat(new ArraySegment<string>(originalStringArray, insertAtPositionZeroBased, originalStringArray.Length - insertAtPositionZeroBased)).ToArray();
