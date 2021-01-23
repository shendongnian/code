    static void ReadFile(int[] districtDataD, string[] districtDataG, string[] districtDataM, int[] districtDataA)
    {
       // Read in the file contents
        string[] lines = File.ReadAllLines("census.txt");
        int i =0;
        //iterate through each line
        foreach(var line in lines)
        {
          //split the line by a comma
          string[] parts = line.Split(',');
                districtDataD[i] = int.Parse(parts[0]);
                districtDataG[i] = parts[1];
                districtDataM[i] = parts[2];
                districtDataA[i] = int.Parse(parts[3]);
                i++;
        }
    }
