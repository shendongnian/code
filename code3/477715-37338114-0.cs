    class Email
    {
        private String value_;
        // Error codes
        const Error E_LENGTH = "An email address must be at least 3 characters long.";
        const Error E_FORMAT = "An email address must be in the 'user@email.com' format.";
        // Private constructor, forcing the use of factory functions
        private Email(String value)
        {
            this.value_ = value;
        }
        // Factory functions
        static public Email createNew(String value)
        {
            validateLength(value, E_LENGTH);
            validateFormat(value, E_FORMAT);
        }
        static public Email createExisting(String value)
        {
            return new Email(value);
        }
        // Static validation methods
        static public void validateLength(String value, Error error = E_LENGTH)
        {
            if (value.length() < 3)
            {
                throw new DomainException(error);
            }
        }
        static public void validateFormat(String value, Error error = E_FORMAT)
        {
            if (/* regular expression fails */)
            {
                throw new DomainException(error);
            }
        }
    }
