    periodList.AddRange(
        from date in weekADates
        from timetable in response.TimeTableWeek
        from schoolclassCode in timetable.WeeklySchoolclassCodes.Values
        select new Period
        {
            LessonNumber = timetable.LessonNumber + 1,
            LessonDate = date,
            SchoolclassCode = schoolclasscode
        });
