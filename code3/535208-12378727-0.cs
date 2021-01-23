     using(StreamWriter outfile3 = new StreamWriter(...))
     {
        count++;
        foreach (string dirFileName in array2)
        {
            if(fourCount == 1)
            {
                outfile3.Close();  // add this
                outfile3 = new StreamWriter(folderPath.Text + "\\" + count + ".txt");
                outfile3.WriteLine(readFromFile);
            }
           ...
        }
     }
