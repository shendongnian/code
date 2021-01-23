    periodList.AddRange(
        weekADates.SelectMany(date => 
        response.TimeTableWeek.SelectMany(timetable =>
        timetable.WeeklySchoolclassCodes.Values.Select(schoolclassCode =>
        new Period
        {
            LessonNumber = timetable.LessonNumber + 1,
            LessonDate = date,
            SchoolclassCode = schoolclasscode
        })));
