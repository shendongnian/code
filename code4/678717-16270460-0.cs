    abstract class ParserBase<T> {
        public abstract T Parse(string input);
    }
    abstract class ThingyParser : ParserBase<Thingy> {
        public override Thingy Parse(string input);
    }
