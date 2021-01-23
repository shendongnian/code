    using System;
    using System.Globalization;
    
    ...
    bool valid;
    DateTime dt;
    valid = DateTime.TryParseExact(inputString, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);
