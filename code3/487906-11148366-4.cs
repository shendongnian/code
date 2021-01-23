    var argsForMethod = new List<string>(args);
    var m = typeof(Program).GetMethod("CreateTaskGroup");
    foreach (var p in m.GetParameters().Skip(args.Length))
        if (p.Attributes.HasFlag(ParameterAttributes.HasDefault))
            argsForMethod.Add((string)p.DefaultValue);
        else
            throw new NotImplementedException();
    var result = (int)m.Invoke(null, argsForMethod.ToArray());
