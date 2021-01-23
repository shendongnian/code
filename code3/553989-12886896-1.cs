    var query = from workoutSession in DatabaseContext.SetOwnable<WorkoutSession>
    select new
    {
         WorkoutSession,
         WorkoutSessionExercises = from workoutSessionExercise in
            DatabaseContext.SetOwnable<WorkoutSessionExercises>
            select new
            {
                WorkoutExercise = from workoutExercise in
                    DatabaseContext.SetOwnable<WorkoutExercise>
                    select workoutExercise
            }
    };
    var results = query.Select(r => r.WorkoutSession).Where(w => w.Id == id);
