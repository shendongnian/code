    string result = "";
    bool minus = false;
    if (value = 0 ) {
        result = "0";
    } else {
        // Begin the string with a minus (`-`) if value is negative
        // and continue the conversion with a positive value.
        if (value < 0) {
             minus = true;
             value = - value;
        }
        // Add decimals to the result as long as the remaining number is not zero.
        while (value > 0) { 
            // Get last decimal using the modulo operator
            int lastDecimal = value % 10;
            // Add the decimal to the result after having converted it to a character
            result = ('0' + lastDecimal) + result;
            // Divide the value by 10. Integer division!
            value = value / 10;
        }
        if (minus) {
            result = "-" + result;
        }
    }
