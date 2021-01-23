    public class SampleAppointmentSource : AppointmentSource
    {
        DateTime date;
        public SampleAppointmentSource()
        {
            date = DateTime.Parse("5/19/2013");
         }
        public override void FetchData(DateTime startDate, DateTime endDate)
        {
            this.AllAppointments.Clear();
            this.AllAppointments.Add(new SampleAppointment()
            {
                StartDate = date.AddDays(1),
                EndDate = date.AddDays(1),
                Subject = "Jackson W/Warren Hayes",
                AdditionalInfo = "Fain Feild",
                Location = "LoserVille,Kentucky",
            });
        }
    }
