    private static string FindAppointmentsAsXmlString(CalendarView calendar, ExchangeService serv)
            {
                FindItemsResults<Appointment> appointments = serv.FindAppointments(
                    WellKnownFolderName.Calendar, calendar);
                
                Mapper.CreateMap<Appointment, DTO.CalendarAppointment>();
    
                var list = appointments.Select(Mapper.Map<DTO.CalendarAppointment>).ToList();
                var serializer = new XmlSerializer(list.GetType());
                var writer = new StringWriter();
                
                try
                {
                    serializer.Serialize(writer, list);
                    Console.WriteLine(writer.GetStringBuilder().ToString());
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Console.ReadLine();
                }
    
                return writer.GetStringBuilder().ToString();
            }
