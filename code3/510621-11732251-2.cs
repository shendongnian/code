     private void SaveDepthData(short[] depthData)
     {
           //initialize a StreamWriter
           StreamWriter sw = new StreamWriter(@"C:/Example.txt");
           //search the depth data and add it to the file
           for (int i = 0; i < depthData.Length; i++)
           {
                sw.WriteLine(depthData[i] + "\n"); //\n for a new line
           }
           //dispose of sw
           sw.Close();
     }      
     ...
     SaveDepthData(depthData);
