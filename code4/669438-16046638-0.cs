        /// <summary>
        /// RegisterAsyncAction registers an asynchronous method that runs
        /// whenever the Command's Execute method is called and doesn't return a
        /// result.
        /// </summary>
        /// <param name="calculationFunc">The function to be run in the
        /// background.</param>
        public static IObservable<Unit> RegisterAsyncAction(this IReactiveAsyncCommand This, 
            Action<object> calculationFunc,
            IScheduler scheduler = null)
        {
            return This.RegisterAsyncFunction(x => { calculationFunc(x); return Unit.Default; }, scheduler);
        }
