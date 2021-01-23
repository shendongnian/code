    public static class RunExtensions
    {
        public static TRun Run<TRun, TActor, TTarget>(this TRun map) 
            where TRun : Run<TActor, TTarget>
        {
            return map;
        }
        public static Run<TActor, TTarget> Run<TActor, TTarget>(this TActor actor)
        {
            return new Run<TActor, TTarget>(actor);
        }
    }
