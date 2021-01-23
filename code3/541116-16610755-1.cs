    class CarSerialNumber : IEquatable<CarSerialNumber> {
        public CarSerialNumber(string value) {
            Validate(value);
            _value = value;
        }
        private Validate(string value) {
            if(value == null) { // Never forget this one ;)
                throw new ArgumentNullException();
            }
            // Rest of validation, throwing exceptions on failure.
        }
        // ... rest ....
    }
You may strongly want to consider making this type sealed. Inheritance of such types may include other traps. (Like magical equatability of incompatible subtypes)
