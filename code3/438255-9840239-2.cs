    new RegexDateTimePattern (
        String.Format(@"(last|next) *({0}).*", String.Join("|", dayList.ToArray())), 
        delegate (Match m) {
            var val = m.Groups[2].Value;
            var direction = (m.Groups[1].Value == "last")? -1 :1;
            var dayOfWeek = dayList.IndexOf(val.Substring(0,3));
            if (dayOfWeek >= 0) {
                var diff = direction*(dayOfWeek - (int)DateTime.Today.DayOfWeek);
                if (diff <= 0 ) { 
                    diff = 7 + diff;
                }
                return DateTime.Today.AddDays(direction * diff);
            }
            return DateTime.MinValue;
        }
    ),
