        static void Main(string[] args)
        {
            //Test Data
            List<CustomizedDataType> dataTypeContaineer1 = new List<CustomizedDataType>();
            dataTypeContaineer1.Add(new CustomizedDataType(10,"Test10"));
            dataTypeContaineer1.Add(new CustomizedDataType(11, "Test11"));
            dataTypeContaineer1.Add(new CustomizedDataType(12, "Test12"));
            //Test Data
            List<CustomizedDataType> dataTypeContaineer2 = new List<CustomizedDataType>();
            dataTypeContaineer2.Add(new CustomizedDataType(100, "Test10"));
            dataTypeContaineer2.Add(new CustomizedDataType(11, "Test11"));
            dataTypeContaineer2.Add(new CustomizedDataType(12, "Test120"));
            //Checking if both the list contains the same types.
            if (dataTypeContaineer1.GetType() == dataTypeContaineer2.GetType())
            {
                //Checking if both the list contains the same count
                if (dataTypeContaineer1.Count == dataTypeContaineer2.Count)
                {
                    //Checking if both the list contains the same data.
                    for (int index = 0; index < dataTypeContaineer1.Count; index++)
                    {
                        if(!dataTypeContaineer1[index].Equals(dataTypeContaineer2[index]))
                        {
                            Console.WriteLine("Mismatch @ Index {0}", index);
                        }
                    }
                }
            }
        }
