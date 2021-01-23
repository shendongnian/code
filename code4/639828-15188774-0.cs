        public sealed class Stage
        {
            public static readonly Stage One = new Stage(TimeSpan.FromHours(1));
            public static readonly Stage Two = new Stage(TimeSpan.FromHours(5));
            // ...
            private readonly TimeSpan time;
            public TimeSpan Time { get { return time; } }
            private Stage(TimeSpan time)
            {
                this.time = time;
            }
        }
