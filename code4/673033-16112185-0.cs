            var availableSlots = new List<AvailableSlot>();
            //Read the record file and populate availableSlots
            DateTime inputStart = DateTime.Now; 
            DateTime inputEnd = DateTime.Now.AddHours(2);
            var isAvailable = availableSlots.Any(a => a.start <= inputStart && a.end >= inputEnd);
