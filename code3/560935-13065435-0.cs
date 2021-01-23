    using System.Linq;
    // some code
    private static void SkipFirst(IList<float> list)
    {
        IList<float> skippedFirst = list.Skip(1).ToList();
    }
