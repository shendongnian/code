    var code = Payments[0].Code;
    for (int i = 1; i < Payments.Count; i++) {
        if (Payments[i].Code != code) {
             throw new Exception();
        }
    }
    return code;
