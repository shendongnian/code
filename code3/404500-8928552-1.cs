    foreach(var asm in AppDomain.CurrentDomain.GetAssemblies())
    {
            foreach (var type in asm.GetTypes())
            {
                if (type.BaseType == this.GetType())
                    yield return type;
            }
    }
