        public class MyEnumerator : IEnumerator
        {
            void IEnumerator.Reset()
            {
                throw new NotImplementedException();
            }
            object IEnumerator.Current
            {
                get { throw new NotImplementedException(); }
            }
            bool IEnumerator.MoveNext()
            {
                throw new NotImplementedException();
            }
        }
