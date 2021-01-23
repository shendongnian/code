    public enum SingularOrPluralCategory {
        Singular,
        // The rest of the PluralCategory enum values
    }
    public class StringForm {
        public string Text {get; private set;}
        public SingularOrPluralCategory Category {get; private set;}
    }
    public interface IString {
        // You may want to omit the setter from the interface, adding it to the class instead
        void SetForm(SingularOrPluralCategory category, string plural);
        StringForm GetForm(SingularOrPluralCategory category, params object[] args);
    }
