    public class AppForm
    {
        public static void WriteLogDataToDb(LogData data)
        {
            using (var db = new LogService.UserActivityDataContext())
            {
                DbLogData logData = AutoMapper.Mapper.Map<LogData, DbLogData>(data);
                int t = (int)data.EventType;
                EventType eventType = db.EventTypes.FirstOrDefault(r => r.Id == t);
                if (eventType == null)
                {
                    eventType = db.EventTypes.Add(new EventType
                    {
                        Event = GetEnumDescriptionAttributeValue(data.EventType),
                        Id = (int)data.EventType
                    });
                    db.SaveChanges();
                }
                logData.EventTypeId = eventType.Id;
                db.LogEvents.Add(logData);
                db.SaveChanges();
            }
        }
    }
