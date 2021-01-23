        public IEnumerator<SomeClass> GetEnumerator()
        {
            if (sourceItems == null)
            {
                yield return SomeClass.Empty;
                //as many times as you want "empty" lines in datagrid
            }
            else
            {
                foreach (var item in sourceItems)
                   yield return item;
            }
        }
