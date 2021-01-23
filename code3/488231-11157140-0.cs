    public class DefaultValueChecker<T> where T : System.Windows.Forms.Control, new()
    {
        public bool DetermineDefaultValue() {
            var control = new T();
            return control.Enabled;
        }
    }
