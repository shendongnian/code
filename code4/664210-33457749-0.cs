    public class Either(of ErrorType, ValueType)
        public readonly Success as boolean
        public readonly Error as ErrorType
        public readonly Value as ValueType
        public sub new(Error as ErrorType)
            me.Success = False
            me.Error = Error
        end sub
        public sub new(Value as ValueType)
            me.Success = True
            me.Value = Value
        end sub
    end class
