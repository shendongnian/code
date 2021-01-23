    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    namespace Sample
    {
        public partial class Sample: System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                NetworkCredential credential = new NetworkCredential("username", "password");
                Service service = new Service("https://myserver/ews/Exchange.asmx", credential);
            try
            {
                IsGreaterThanOrEqualTo restriction1 = new IsGreaterThanOrEqualTo(AppointmentPropertyPath.StartTime, DateTime.Today);
                IsLessThanOrEqualTo restriction2 = new IsLessThanOrEqualTo(AppointmentPropertyPath.EndTime, DateTime.Today.AddDays(1));
                And restriction3 = new And(restriction1, restriction2);
                FindItemResponse response = service.FindItem(StandardFolder.Calendar, AppointmentPropertyPath.AllPropertyPaths, restriction3);
                for (int i = 0; i < response.Items.Count; i++)
                {
                    if (response.Items[i] is Appointment)
                    {
                        Appointment appointment = (Appointment)response.Items[i];
                        lblSubject.Text = "Subject = " + appointment.Subject;
                        lblStartTime.Text = "StartTime = " + appointment.StartTime;
                        lblEndTime.Text = "EndTime = " + appointment.EndTime;
                        lblBodyPreview.Text = "Body Preview = " + appointment.BodyPlainText;
                        
                    }
                }
                
            }
            catch (ServiceRequestException ex)
            {
                lblError.Text= "Error: " + ex.Message;
                lblXmlError.Text = "Error: " + ex.XmlMessage;
                Console.Read();
            }
            catch (WebException ex)
            {
                lblWebError.Text = "Error: " + ex.Message;
            }
        }
    }
