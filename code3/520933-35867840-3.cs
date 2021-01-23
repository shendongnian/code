        public static Expression<Func<ClientEvent, bool>> ClientHasAttendeeStatus(
            IEnumerable<EventEnums.AttendeeStatus> statuses)
        {
            return ce => ce.Event.AttendeeStatuses
                .Where(a => a.ClientId == ce.Client.Id)
                .Select(a => a.Status.Value)
                .Any(x => statuses.Contains(x));
        }
