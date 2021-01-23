    class EventLogConverter : ITypeConverter<EventLog, ICollection<EventDTO>>
    {
        public ICollection<EventDTO> Convert(ResolutionContext context)
        {
            EventLog log = (EventLog)context.SourceValue;
            List<EventDTO> result = new List<EventDTO>();
            foreach (var e in log.Events)
            {
                var dto = Mapper.Map<EventDTO>(e); // map message and event id
                Mapper.Map(log, dto); // map system id and user id
                result.Add(dto);
            }
            return result;
        }
    }
