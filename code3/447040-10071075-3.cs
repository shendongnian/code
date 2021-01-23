    public static IEnumerable<TResult> RepeatAction<TResult>(Action<TResult> elementAction, int count)
    {
        for (int i = 0; i < count; i++)
        {
            yield return elementAction();
        }
        yield break;
    }
    usage
    RepeatAction(()=>new double[12], 12);
