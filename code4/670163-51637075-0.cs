    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Management.Infrastructure;
    using Microsoft.Management.Infrastructure.Generic;
    using Microsoft.Management.Infrastructure.Options;
    namespace MMITest
    {
    class Program
    {
        static void Main(string[] args)
        {
            using (var session = CimSession.Create("localhost"))
            {
                using (var cimMethodParameters = new CimMethodParametersCollection())
                {
                    cimMethodParameters.Add(CimMethodParameter.Create("Name", @"\\PrintServerName\PrinterName", CimFlags.Parameter));
                    session.InvokeMethod(@"root\cimv2", "Win32_Printer", "AddPrinterConnection", cimMethodParameters);
                }
            }
            
            Console.ReadLine();
        }
    }
}
