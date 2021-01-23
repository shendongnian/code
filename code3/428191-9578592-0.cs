    public static class WeightGoalStatusExtensions
    {
        public static string ToLocalizedString(this WeightGoalStatus status)
        {
            switch (status)
            {
               case WeightGoalStatus.InProgress
                  return Resources.WeightGoalStatus.InProgress_ToLocalizedString;
               // others
            }
        }
    }
