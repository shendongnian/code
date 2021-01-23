        static IList<Action> getDelegatesFromObject(Object obj)
        {
            Type type = obj.GetType();
            List<Action> Actions = new List<Action>();
            foreach (MethodInfo mi in type.GetMethods())
            {
                MethodInfo mi1 = mi;
                Actions.Add(
                    () => mi1.Invoke(obj, new object[] {})
                );
            }
            return Actions;
        }
