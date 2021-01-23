    class EventLogConverter : ITypeConverter<EventLog, IEnumerable<EventDTO>>
    {
        public IEnumerable<EventDTO> Convert(ResolutionContext context)
        {
            EventLog log = (EventLog)context.SourceValue;
            foreach (var dto in log.Events.Select(e => Mapper.Map<EventDTO>(e)))
            {
                Mapper.Map(log, dto); // map system id and user id
                yield return dto;
            }
        }
    }
