cs
using System;
using System.Diagnostics;
namespace Union {
    [DebuggerDisplay("{currType}: {ToString()}")]
    public struct Either<TP, TA> {
        enum CurrType {
            Neither = 0,
            Primary,
            Alternate,
        }
        private readonly CurrType currType;
        private readonly TP primary;
        private readonly TA alternate;
        public bool IsNeither => currType == CurrType.Primary;
        public bool IsPrimary => currType == CurrType.Primary;
        public bool IsAlternate => currType == CurrType.Alternate;
        public static implicit operator Either<TP, TA>(TP val) => new Either<TP, TA>(val);
        public static implicit operator Either<TP, TA>(TA val) => new Either<TP, TA>(val);
        public static implicit operator TP(Either<TP, TA> @this) => @this.Primary;
        public static implicit operator TA(Either<TP, TA> @this) => @this.Alternate;
        public override string ToString() {
            string description = IsNeither ? "" :
                $": {(IsPrimary ? typeof(TP).Name : typeof(TA).Name)}";
            return $"{currType.ToString("")}{description}";
        }
        public Either(TP val) {
            currType = CurrType.Primary;
            primary = val;
            alternate = default(TA);
        }
        public Either(TA val) {
            currType = CurrType.Alternate;
            alternate = val;
            primary = default(TP);
        }
        public TP Primary {
            get {
                Validate(CurrType.Primary);
                return primary;
            }
        }
        public TA Alternate {
            get {
                Validate(CurrType.Alternate);
                return alternate;
            }
        }
        private void Validate(CurrType desiredType) {
            if (desiredType != currType) {
                throw new InvalidOperationException($"Attempting to get {desiredType} when {currType} is set");
            }
        }
    }
}
The above class represents a type that can be *either* TP _or_ TA. You can use it as such (the types refer back to my original answer):
cs
// ...
public static Either<FishingBot, ConcreteMixer> DemoFunc(Either<JumpRope, PiCalculator> arg) {
  if (arg.IsPrimary) {
    return new FishingBot(arg.Primary);
  }
  return new ConcreteMixer(arg.Secondary);
}
// elsewhere:
var fishBotOrConcreteMixer = DemoFunc(new JumpRope());
var fishBotOrConcreteMixer = DemoFunc(new PiCalculator());
Important Notes:
 * You'll get runtime errors if you don't check `IsPrimary` first.
 * You can check any of `IsNeither` `IsPrimary` or `IsAlternate`.
 * You can access the value through `Primary` and `Alternate`
 * There are implicit converters between TP/TA and Either<TP, TA> to allow you to pass either the values or an `Either` anywhere where one is expected. If you _do_ pass an `Either` where a `TA` or `TP` is expected, but the `Either` contains the wrong type of value you'll get a runtime error.
I typically use this where I want a method to return either a result or an error. It really cleans up that style code. I also very occasionally (**rarely**) use this as a replacement for method overloads. Realistically this is a very poor substitute for such an overload.
