    var pairIsValidOrDie = new Func<string[], bool>(pair => {
        float amt;
        if (pair.Length != 2 || !float.TryParse(pair[1], out amt)) throw new ArgumentException("ERROR: invalid price override string);
        return true;
    });
    var orr = from pco in (overrrides ?? string.Empty).Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
              let pair = pco.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)
              where pairIsValidOrDie(pair)
              select new KeyValuePair<string, float>(pair[0], float.Parse(pair[1]));
