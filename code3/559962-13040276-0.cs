    public class MiniProfilerStep : IDisposable
    {
        private readonly MiniProfiler _profiler;
        private readonly IDisposable _step;
        public MiniProfilerStep(MiniProfiler profiler, string operation)
        {
            _profiler = profiler;
            _step = _profiler.Step(operation);
        }
        public void Dispose()
        {
            _step.Dispose();
            MiniProfiler.Settings.Storage.Save(_profiler);
        }
    }
