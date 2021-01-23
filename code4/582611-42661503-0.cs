    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class NumberRangeHelper
    {
        /// <summary>
        /// Converts a string of comma separated list of numbers and ranges to a list of individual numbers it represents.
        /// </summary>
        /// <param name="numbers">Range in form of <c>"2,4-8,11,15-22,39"</c></param>
        /// <returns>A list of numbers</returns>
        public static List<int> ConvertRangeStringToNumberList(string numbers)
        {
            var numbersSplit = numbers.Split(",".ToCharArray());
            var convertedNumbers = new List<int>();
            foreach (var strNumber in numbersSplit)
            {
                int number;
                if (int.TryParse(strNumber, out number))
                {
                    convertedNumbers.Add(number);
                }
                else
                {
                    // try and delimited by range
                    if (strNumber.Contains("-"))
                    {
                        var splitRange = strNumber.Split("-".ToCharArray());
                        if (splitRange.Length == 2)
                        {
                            int firstNumber;
                            int secondNumber;
                            if (Int32.TryParse(splitRange[0], out firstNumber) &&
                                Int32.TryParse(splitRange[1], out secondNumber))
                            {
                                for (var i = firstNumber; i <= secondNumber; ++i)
                                {
                                    convertedNumbers.Add(i);
                                }
                            }
                        }
                    }
                }
            }
            return convertedNumbers;
        }
        /// <summary>
        /// Converts a list of numbers to their concise range representation.
        /// </summary>
        /// <param name="numbers">A list of numbers such as <c>new[] { 1, 2, 3, 4, 5, 12, 13, 14, 19 }</c></param>
        /// <returns>A string like <c>"1-5, 12-14, 19"</c></returns>
        public static string ConvertNumberListToRangeString(IEnumerable<int> numbers)
        {
            var items = numbers.Distinct()
                .Select((n, i) => new { number = n, group = n - i })
                .GroupBy(n => n.group)
                .Select(g => (g.Count() >= 3)
                        ? g.First().number + "-" + g.Last().number
                        : String.Join(", ", g.Select(x => x.number))
                )
                .ToList();
            return String.Join(", ", items);
        }
    }
