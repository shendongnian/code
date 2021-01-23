    namespace Shared.Enumerations
    {
        [Flags]
        public enum TaskStatusEnum
        {
            NotSet = 0,
            Open = 1,
            Canceled = 2,
            Complete = 4,
            OnHold = 8,
            Inactive = 32,
    		All = Open | Canceled | Complete | OnHold | Inactive
        }
    } 
