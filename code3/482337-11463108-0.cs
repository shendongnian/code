        static void Main(string[] args)
        {
            var dcsInOrder = (from DomainController c in Domain.GetCurrentDomain().DomainControllers
                              let responseTime = Pinger(c.Name)
                              where responseTime >=0
                              let pdcStatus = c.Roles.Contains(ActiveDirectoryRole.PdcRole)
                              orderby pdcStatus, responseTime
                              select new {DC = c, ResponseTime = responseTime} 
                              ).ToList();
            foreach (var dc in dcsInOrder)
            {
                System.Console.WriteLine(dc.DC.Name + " - " + dc.ResponseTime);
            }
            System.Console.ReadLine();
        }
        private static int Pinger(string address)
        {
            Ping p = new Ping();
            try
            {
                PingReply reply = p.Send(address, 3000);
                if (reply.Status == IPStatus.Success) return (int)reply.RoundtripTime;
            }
            catch { }
            return -1;
        }
