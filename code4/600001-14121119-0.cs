        public class BaseClass
        {
                protected Func<string, ActionResult> tempFunction;
                public virtual void AssertThrowsNullReferenceOrInvalidOperation()
                {
                    if (tempFunction != null)
                    {
                        Assert.Throws<NullReferenceException>(() => tempFunction(null));
                        Assert.Throws<InvalidOperationException>(() => tempFunction(string.Empty));
                        Assert.Throws<InvalidOperationException>(() => tempFunction(" "));
                    }
                }
        }
