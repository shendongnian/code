    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ComponentModel;
    using System.ServiceProcess;
    using Microsoft.SharePoint;
    using Microsoft.SharePoint.Administration;
    using Microsoft.SharePoint.Administration.Health;
    namespace ConsoleApplication1
    {
    class Program
    {
    static void Main(string[] args)
    {
        var solution = SPFarm.Local.Solutions["Your Service Application Name.wsp"];
        string serverName = string.Empty;
        foreach (SPServer server in solution.DeployedServers)
        {
            serverName += server.Name;
            Console.WriteLine(server.Name);
        }
        if (solution != null)
        {
            if (solution.Deployed)
            {
                Console.WriteLine("{0} is currently deployed on: {1}", solution.Name, serverName);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Error!  Solution not deployed!");
                Console.ReadLine();
            }
        }
      }
     }
    }
