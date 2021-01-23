    public static class TimerEx {
        public static void DoThings(this ITimer timer, IEnumerable<DelayedAction> actions) {
            timer.DoThings(actions.GetEnumerator());
        }
        static void DoThings(this ITimer timer, IEnumerator<DelayedAction> actions) {
            if (!actions.MoveNext())
                return;
            var first = actions.Current;
            Action onTick = null;
            onTick = () => {
                timer.IsEnabled = false;
                first.Action();
                // ReSharper disable AccessToModifiedClosure
                timer.Tick -= onTick;
                // ReSharper restore AccessToModifiedClosure
                onTick = null;
                timer.DoThings(actions);
            };
            timer.Tick += onTick;
            timer.Interval = first.Delay;
            timer.IsEnabled = true;
        }
    }
