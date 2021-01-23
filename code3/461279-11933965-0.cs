        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using Microsoft.SqlServer.Dac;
        using System.IO;
        namespace ConsoleApplication3
        {
            class Program
            {
                private static TextWriter output = new StreamWriter("output.txt", false);
                static void Main(string[] args)
                {
           
                    Console.Write("Connection String:");
                    //Class responsible for the deployment. (Connection string supplied by console input for now)
                    DacServices dbServices = new DacServices(Console.ReadLine());
            
                    //Wire up events for Deploy messages and for task progress (For less verbose output, don't subscribe to Message Event (handy for debugging perhaps?)
                    dbServices.Message += new EventHandler<DacMessageEventArgs>(dbServices_Message);
                    dbServices.ProgressChanged += new EventHandler<DacProgressEventArgs>(dbServices_ProgressChanged);
                    //This Snapshot should be created by our build process using MSDeploy
                    Console.WriteLine("Snapshot Path:");
                    DacPackage dbPackage = DacPackage.Load(Console.ReadLine());
           
            
           
                    DacDeployOptions dbDeployOptions = new DacDeployOptions();
                    //Cut out a lot of options here for configuring deployment, but are all part of DacDeployOptions
                    dbDeployOptions.SqlCommandVariableValues.Add("debug", "false");
       
                    dbServices.Deploy(dbPackage, "trunk", true, dbDeployOptions);
                    output.Close();
            
                }
                static void dbServices_Message(object sender, DacMessageEventArgs e)
                {
                    output.WriteLine("DAC Message: {0}", e.Message);
                }
                static void dbServices_ProgressChanged(object sender, DacProgressEventArgs e)
                {
                    output.WriteLine(e.Status + ": " + e.Message);
                }
            }
        }
