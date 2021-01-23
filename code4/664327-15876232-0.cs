    while (i < SIZE && i <= 0)
    {
        foreach (string line in File.ReadAllLines("census.txt"))
        {
            if (!string.IsNullOrEmpty(line))
            {
                string[] parts = line.Split(',');
                districtDataD[i] = int.Parse(parts[0]);
                districtDataG[i] = parts[1];
                districtDataM[i] = parts[2];
                districtDataA[i] = int.Parse(parts[3]);
                i++;
            }
        }
    }
