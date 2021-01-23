    public class MySpecializedContainer<T> where T : new()
    {
        private class MySubClass : MyClass
        {
            private Element wrappedElement;
            public MySubClass(Element wrappedElement)
            {
                this.wrappedElement = wrappedElement;
            }
            public override int a
            {
                set
                {
                    base.a = value;
                    wrappedElement.Update(value);
                }
            }
        }
    }
