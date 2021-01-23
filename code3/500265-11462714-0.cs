    // Covariance
    typeof(IEnumerable<object>).IsAssignableFrom(typeof(IEnumerable<string>)).Dump(); // true
    typeof(IEnumerable<string>).IsAssignableFrom(typeof(IEnumerable<object>)).Dump(); // false
    
    // Contravariance
    typeof(Action<string>).IsAssignableFrom(typeof(Action<object>)).Dump(); // true
    typeof(Action<object>).IsAssignableFrom(typeof(Action<string>)).Dump(); // false
