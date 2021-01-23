    List<BankInfo> all_branches = new List<BankInfo>();
    Equipment.set_slot = "Mail";
    try
    {
        using (System.IO.StreamReader sr = new System.IO.StreamReader("input_file.txt"))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if(line != null && line.Trim().Length > 0 && line.Contains(","))
                {
                    string[] temp = line.Split(',');
                    if(temp.Length >= 4)
                    {
                        all_branches = addToBankInfo(temp[0], temp[1], temp[2], Convert.ToInt32(temp[3]), all_branches);
                    }
                }
            }
        }
    }
    catch
    {
    }
