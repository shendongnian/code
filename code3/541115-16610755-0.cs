Your UI is accepting a sequence of characters from the User, whether it be from a TextBox or the console input. At this level, it makes sense to store this sequence of characters into a string object, since it is what it is: a sequence of characters.
On the business rule side, on the contrary, it should already be validated. Indeed, only a subset of the valid strings are of interest to the BRs. Therefore, your BRs should manipulate another type that is not string. A user-defined type, in C#, is either a class or a struct.
So let's write this type. I choose to create a class, because there are less syntactic caveats.
    class CarSerialNumber {
    }
A car serial number is semantically a value, not an object. It has value semantics. Its value can be stored into a string, and we have to redefine Equals(object), GetHashCode(), and it is equatable to itself, so it can implement IEquatable<CarSerialNumber>.
    class CarSerialNumber : IEquatable<CarSerialNumber> {
        string _value;
        
        public override bool Equals(object right) {
            if(this == right) {
                return true;
            }
            if(right == null) {
                return false;
            }
            if(!right is CarSerialNumber) {
                return false;
            }
            return Equals((CarSerialNumber)right);
        }
        public override int GetHashCode() {
            return _value.GetHashCode();
        }
        public bool Equals(CarSerialNumber right) {
            return _value == right._value;
        }
    }
It should be constructed with a string value, and be immutable.
    class CarSerialNumber : IEquatable<CarSerialNumber> {
        public CarSerialNumber(string value) {
            _value = value;
        }
        readonly string _value;
        // ... rest ....
    }
And there we just found the hinge. This constructor is the turning point from the string to the CarSerialNumber. Moreover, a CarSerialNumber should not be constructible with an invalid string. As the typesystem cannot guarantee at this point that the parameter string is a valid car serial number, the constructor has to bail out with an exception.
