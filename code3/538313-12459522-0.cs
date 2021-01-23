    public struct IpRange
    {
        public IPAddress LowerIP;
        public IPAddress UpperIP;
        public IpRange(IPAddress lowerIP, IPAddress upperIP)
        {
            LowerIP = lowerIP;
            UpperIP = upperIP;
        }
    }
        public bool CheckIsIpPublic(string adress, List<IpRange> rangeList)
        {
            foreach (var range in rangeList)
            {
                List<int> adressInt = adress.Split('.').Select(str => int.Parse(str)).ToList();
                List<int> lowerInt = range.LowerIP.ToString().Split('.').Select(str => int.Parse(str)).ToList();
                List<int> upperInt = range.UpperIP.ToString().Split('.').Select(str => int.Parse(str)).ToList();
                if (adressInt[0] >= lowerInt[0] && adressInt[0] <= upperInt[0] &&
                    adressInt[1] >= lowerInt[1] && adressInt[1] <= upperInt[1] &&
                    adressInt[2] >= lowerInt[2] && adressInt[2] <= upperInt[2] &&
                    adressInt[3] >= lowerInt[3] && adressInt[3] <= upperInt[3])
                {
                    return true;
                }
            }
            return false;
        }
