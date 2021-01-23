        public static void Do(Type source, params CaseInfo[] cases)
        {
            foreach (var entry in cases.Where(entry => entry.IsDefault || entry.Target.IsAssignableFrom(source)))
            {
                entry.Action(source);
                break;
            }
        }
