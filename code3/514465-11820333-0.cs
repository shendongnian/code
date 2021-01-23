        private List<WorkoutFormModel> ExtendSchedule(Schedule schedule, IEnumerable<WorkoutInfo> oneWeekWorkouts)
        {
            var workoutList = new List<WorkoutFormModel>();
            foreach (var workoutStart = schedule.FromDate; workoutStart <= schedule.ToDate; workoutStart = workoutStart.AddDays(7))
            {
                workoutList.AddRange(oneWeekWorkouts.Select(workout => new WorkoutFormModel
                                     {
                                         ScheduleId = schedule.Id,
                                         Date = workoutStart.Add(workout.WeekOffset),
                                         StartTime = ?,
                                         EndTime = ?,
                                         InstructorId = workout.Instructor.Id,
                                         CourseId = workout.Course.Id
                                     }));
            }
            
            return workoutList;
        }
