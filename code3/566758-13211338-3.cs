    namespace ParseTest
    {
        using System;
        using System.Collections.Generic;
        using System.Globalization;
        using System.Threading;
        using System.Linq;
        static class Program
        {
            static void Main(string[] args)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
                var input = "Sets all the farm animals CAT 3 5 DOG 21.3 5.23 MOUSE 1 0 1 COW 12.25";
                Console.WriteLine(input);
                var ps = new ParserState(input.Split(' '));
                var result = ps.ParseAnimals();
                if (result.Success)
                {
                    foreach (var animal in result.Value.Where(v => !(v is Unknown)))
                    {
                        Console.WriteLine(animal);
                    }
                }
                else
                {
                    Console.WriteLine("Parse failure");
                }
            }
        }
        // ParserState tracks where we are in the input
        class ParserState
        {
            public readonly string[] Tokens;
            public int CurrentPosition;
            public ParserState(string[] tokens) 
            {
                Tokens = tokens ?? new string[0];
            }
        
            public string Peek
            {
                get
                {
                    if (CurrentPosition < 0)
                    {
                        return "";
                    }
                    if (CurrentPosition >= Tokens.Length)
                    {
                        return "";
                    }
                    return Tokens[CurrentPosition];
                }
            }
            public string PeekAndAdvance ()
            {
                var result = Peek;
                ++CurrentPosition;
                return result;
            }
            public bool EndOfStream
            {
                get { return CurrentPosition >= Tokens.Length; }
            }
        }
        struct Empty
        {
        
        }
        // ParseResult are the result of parsers, it might be a succcess or failure
        interface IParseResult<out T>
        {
            ParserState State { get; }
            bool Success { get; }
            T Value { get; }
        }
        class ParseResult<T> : IParseResult<T>
        {
            readonly ParserState m_state;
            readonly bool m_success;
            readonly T m_value;
            public ParseResult(ParserState state, bool success, T value)
            {
                m_state = state;
                m_success = success;
                m_value = value;
            }
            public ParserState State
            {
                get { return m_state; }
            }
            public bool Success
            {
                get { return m_success; }
            }
            public T Value 
            {
                get { return m_value; }
            }
        }
        static class ParserExtensions
        {
            public static IParseResult<T> Result<T>(this ParserState ps, bool success, T value)
            {
                return new ParseResult<T>(ps, success, value);
            }
            public static IParseResult<T> Success<T>(this ParserState ps, T value)
            {
                return ps.Result(true, value);
            }
            public static IParseResult<T> Failure<T>(this ParserState ps)
            {
                return ps.Result(true, default(T));
            }
            public static bool AttemptTo<T>(this ParserState ps, Func<IParseResult<T>> action)
            {
                T value;
                return ps.AttemptTo(action, out value);
            }
            // Attempts to run a parser, 
            // if the parser fails the parser state is returned to its previous state
            public static bool AttemptTo<T>(this ParserState ps, Func<IParseResult<T>> action, out T value)
            {
                value = default(T);
                if (ps.EndOfStream)
                {
                    return false;
                }
                var currentPos = ps.CurrentPosition;
                var result = action();
                if (result.Success)
                {
                    value = result.Value;
                }
                else
                {
                    ps.CurrentPosition = currentPos;
                }
                return result.Success;
            }
            // Attempts to run a parser many times and build an array of values, 
            // if the parser fails the parser state is returned to its previous state
            // and the result is returned
            public static bool AttemptMany<T>(this ParserState ps, Func<IParseResult<T>> action, out T[] values)
            {
                values = new T[0];
                if (ps.EndOfStream)
                {
                    return true;
                }
                var parsedValues = new List<T>();
                var currentPos = ps.CurrentPosition;
                IParseResult<T> result;
                while ((result = action ()).Success)
                {
                    currentPos = ps.CurrentPosition;
                    parsedValues.Add(result.Value);
                }
                ps.CurrentPosition = currentPos;
                values = parsedValues.ToArray();
                return true;
            }
            static IParseResult<Empty> ParseToken(this ParserState ps, string token)
            {
                var value = new Empty();
                var result = ps.PeekAndAdvance().Equals(token, StringComparison.OrdinalIgnoreCase);
                return ps.Result(result, value);
            }
            static IParseResult<double> ParseDouble(this ParserState ps)
            {
                double value;
                var result = double.TryParse(ps.PeekAndAdvance(), out value);
                return ps.Result(result, value);
            }
            static IParseResult<Cat> ParseCat(this ParserState ps)
            {
                var value = new Cat();
                var result = 
                        ps.AttemptTo (() => ps.ParseToken("CAT"))
                    &&  ps.AttemptTo (ps.ParseDouble, out value.A)
                    &&  ps.AttemptTo (ps.ParseDouble, out value.B)
                    ;
                return ps.Result(result, value);
            }
            static IParseResult<Dog> ParseDog(this ParserState ps)
            {
                var value = new Dog();
                var result =
                        ps.AttemptTo(() => ps.ParseToken("DOG"))
                    &&  ps.AttemptTo(ps.ParseDouble, out value.A)
                    &&  ps.AttemptTo(ps.ParseDouble, out value.B)
                    ;
                return ps.Result(result, value);
            }
            static IParseResult<Mouse> ParseMouse(this ParserState ps)
            {
                var value = new Mouse();
                var result =
                        ps.AttemptTo(() => ps.ParseToken("MOUSE"))
                    &&  ps.AttemptTo(ps.ParseDouble, out value.A)
                    &&  ps.AttemptTo(ps.ParseDouble, out value.B)
                    &&  ps.AttemptTo(ps.ParseDouble, out value.C)
                    ;
                return ps.Result(result, value);
            }
            static IParseResult<Cow> ParseCow(this ParserState ps)
            {
                var value = new Cow();
                var result =
                        ps.AttemptTo(() => ps.ParseToken("COW"))
                    &&  ps.AttemptTo(ps.ParseDouble, out value.A)
                    ;
                return ps.Result(result, value);
            }
            static IParseResult<Unknown> ParseUnknown(this ParserState ps)
            {
                ps.PeekAndAdvance();
                return ps.Success(new Unknown());
            }
            static IParseResult<Animal> ParseAnimal(this ParserState ps)
            {
                Animal value = null;
                var result =
                        ps.AttemptTo(ps.ParseCat    , out value)
                    ||  ps.AttemptTo(ps.ParseDog    , out value)
                    ||  ps.AttemptTo(ps.ParseMouse  , out value)
                    ||  ps.AttemptTo(ps.ParseCow    , out value)
                    ||  ps.AttemptTo(ps.ParseUnknown, out value)
                    ;
                return ps.Result(result, value);
            }
            public static IParseResult<Animal[]> ParseAnimals(this ParserState ps)
            {
                Animal[] value;
                var result = ps.AttemptMany(ps.ParseAnimal, out value);
                return ps.Result(result, value);
            }
        }
        class Animal
        {
        
        }
    
        class Cat : Animal
        {
            public double A;
            public double B;
            public override string ToString()
            {
                return new {Type = "CAT", A, B}.ToString();
            }
        }
        class Dog : Animal
        {
            public double A;
            public double B;
            public override string ToString()
            {
                return new { Type = "DOG", A, B }.ToString();
            }
        }
        class Mouse : Animal
        {
            public double A;
            public double B;
            public double C;
            public override string ToString()
            {
                return new { Type = "MOUSE", A, B, C }.ToString();
            }
        }
        class Cow : Animal
        {
            public double A;
            public override string ToString()
            {
                return new { Type = "COW", A}.ToString();
            }
        }
        class Unknown : Animal
        {
            public override string ToString()
            {
                return new { Type = "UNKNOWN"}.ToString();
            }
        }
    }
