    public class MonoBehavior
    {
        private void InitSubclass()
        {
            var methods = new[] { "OnGUI", "OnLoad" }; //etc
            foreach (string methodName in methods)
            {
                MethodInfo method = this.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
                if (method != null)
                {
                    method.Invoke(this, new object[0]);
                }
            }
        }
    }
