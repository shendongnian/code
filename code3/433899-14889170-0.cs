    private static T CloneShallow<T>(T i) {
        return
            (T)i.GetType()
                .GetMethod(
                    "MemberwiseClone",
                    BindingFlags.Instance | BindingFlags.NonPublic
                ).Invoke(i, null);
    }
