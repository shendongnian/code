    .Select<ConsoleKey?>(c =>
        {
            return Enum.TryParse<ConsoleKey>(a.ToString().ToUpper(), out ck) ?
                ck;
                (ConsoleKey?)null;
        }
    .Where(ck => ck.HasValue); // where parse hasn't worked
    .Select(ck => ck.Value);
