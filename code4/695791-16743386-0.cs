    void SuspiciousFunction(string name, long count) {
        try {
            // The code of your function goes here
        } catch (Exception e) {
            var args = new Dictionary<string,object> {
                { "name" , name  }
            ,   { "count", count }
            };
            throw new MySpecialException(e, args);
        }
    }
