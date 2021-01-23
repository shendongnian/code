    public class RomanNumber
    {
        public string Numeral { get; set; }
        public int Value { get; set; }
        public int Hierarchy { get; set; }
    }
    public List<RomanNumber> RomanNumbers = new List<RomanNumber>
        {
            new RomanNumber {Numeral = "M", Value = 1000, Hierarchy = 4},
            //{"CM", 900},
            new RomanNumber {Numeral = "D", Value = 500, Hierarchy = 4},
            //{"CD", 400},
            new RomanNumber {Numeral = "C", Value = 100, Hierarchy = 3},
            //{"XC", 90},
            new RomanNumber {Numeral = "L", Value = 50, Hierarchy = 3},
            //{"XL", 40},
            new RomanNumber {Numeral = "X", Value = 10, Hierarchy = 2},
            //{"IX", 9},
            new RomanNumber {Numeral = "V", Value = 5, Hierarchy = 2},
            //{"IV", 4},
            new RomanNumber {Numeral = "I", Value = 1, Hierarchy = 1}
        };
    /// <summary>
    /// Converts the roman numeral to int, assumption roman numeral is properly formatted.
    /// </summary>
    /// <param name="romanNumeralString">The roman numeral string.</param>
    /// <returns></returns>
    private int ConvertRomanNumeralToInt(string romanNumeralString)
    {
        if (romanNumeralString == null) return int.MinValue;
        var total = 0;
        for (var i = 0; i < romanNumeralString.Length; i++)
        {
            // get current value
            var current = romanNumeralString[i].ToString();
            var curRomanNum = RomanNumbers.First(rn => rn.Numeral.ToUpper() == current.ToUpper());
            // last number just add the value and exit
            if (i + 1 == romanNumeralString.Length)
            {
                total += curRomanNum.Value;
                break;
            } 
            // check for exceptions IV, IX, XL, XC etc
            var next = romanNumeralString[i + 1].ToString();
            var nextRomanNum = RomanNumbers.First(rn => rn.Numeral.ToUpper() == next.ToUpper());
            // exception found
            if (curRomanNum.Hierarchy == (nextRomanNum.Hierarchy - 1))
            {
                total += nextRomanNum.Value - curRomanNum.Value;
                i++;
            }
            else
            {
                total += curRomanNum.Value;
            }
        }
        return total;
    }
