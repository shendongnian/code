    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using CrystalDecisions;
    using CrystalDecisions.CrystalReports;
    using CrystalDecisions.CrystalReports.Engine;
    namespace Test.Utilities
    {
       public class ReportFactory
       {
           protected static Queue reportQueue = new Queue();
           protected static ReportClass CreateReport(Type reportClass)
          {
            object report = Activator.CreateInstance(reportClass);
            reportQueue.Enqueue(report);
            return (ReportClass)report;
          }
        public static ReportClass GetReport(Type reportClass)
        {
            //75 is my print job limit.
            if (reportQueue.Count > 75) ((ReportClass)reportQueue.Dequeue()).Dispose();
            return CreateReport(reportClass);
        }
      } 
    }
