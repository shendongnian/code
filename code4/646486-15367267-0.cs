    public class A
    {
        public void Do<T>()
        {
            if(typeof(T).IsValueType){
                // nasty reflection to call DoValueType
            }
            else {
                // nasty reflection to call DoReferenceType
            }
        }
        private void DoReferenceType<T>() where T : class {
        }
        private void DoValueType<T>() where T : struct {
        }
    }
