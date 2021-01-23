    public static IEnumerator UntilDone(AsyncOperation op)
    {
      while (!op.isDone) {
        yield return op;
      }
    }
    //in a method:
    yield return StartCoroutine(UntilDone(obj));
