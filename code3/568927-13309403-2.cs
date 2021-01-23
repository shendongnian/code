    public static bool IsMissedFire(this IJobExecutionContext context, int offsetMilliseconds)
    {
        if (!context.ScheduledFireTimeUtc.HasValue)
            return false;
        if (!context.FireTimeUtc.HasValue)
            return false;
        
        var scheduledFireTimeUtc = context.ScheduledFireTimeUtc.Value;
        var fireTimeUtc = context.FireTimeUtc.Value;
        return fireTimeUtc.Subtract(scheduledFireTimeUtc).TotalMilliseconds > offsetMilliseconds;
    }
