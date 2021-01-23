        // For I/O
        using System.IO;  
        // Output Stream Writer variable
        StreamWriter yourOSW;  
        // Open the file
        yourOSW = new StreamWriter(fileName); 
        // To declare array
        byte[,] yourArray = new byte[numRows, numColumns];  
        // Data value
        byte num = 0;  
        // To fill array (example)
        for(byte i = 0; i < numRows; i++)
        {
            for(byte j = 0; j < numColumns; j++)
            {
                yourArray[i,j] = num;
                num++;
            }
        }
        // To write array to file
        for(byte i = 0; i < numRows; i++)
        {
            for(byte j = 0; j < numColumns; j++)
            {
                yourOSW.WriteLine(yourArray[i,j]);
            }
        }
