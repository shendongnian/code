    namespace TelephoneNumbers
    {
        class TelephoneNumbersFileReader
        {
            public void storeArray()
            {
                const int SIZE = 7;
                string[] AllPhoneDetails = new string[SIZE];
                int index = 0;
                StreamReader inputFile;
                inputFile = File.OpenText("TelephoneNumbers.txt");
            }
        }
    }
