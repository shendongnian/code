    using System;
    using Outlook = Microsoft.Office.Interop.Outlook;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Outlook.Application ol= new Outlook.Application();
                Outlook.AppointmentItem cal = ol.CreateItem(Outlook.OlItemType.olAppointmentItem);
                cal.Start = DateTime.Now;
                cal.End = DateTime.Now.AddMinutes(30);
                cal.Subject = "Test";
                cal.Save();
            }
        }
    }
