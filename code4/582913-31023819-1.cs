    class DecompileMe
    {
        DecompileMe(Action<Action> callable1, Action<Action> callable2)
        {
            var helper = new LambdaHelper();
            helper.p1 = 1;
            helper.p2 = "hello";
            callable1(helper.Lambda1);
            callable2(helper.Lambda2);
        }
        [CompilerGenerated]
        private sealed class LambdaHelper
        {
            public int p1;
            public string p2;
            public void Lambda1() { ++p1; }
            public void Lambda2() { p2.ToString(); ++p1; }
        }
    }
