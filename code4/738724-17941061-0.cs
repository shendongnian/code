        int[] maxIP = new int[] { 10, 255, 15, 30 };
        int[] minIP = new int[] { 10, 100, 12, 21 };
        char[] sep = new char[] { '.' };
        var ip = "10.100.16.21";
        string[] splitted = ip.Split(sep);
        for (int i = 0; i < splitted.Length; i++)
        {
            if (int.Parse(splitted[i]) > maxIP[i])
            {
                Console.WriteLine("IP greather than max");
                break;
            }
            else if (int.Parse(splitted[i]) < minIP[i])
            {
                Console.WriteLine("IP less than min");
                break;
            }
        }
