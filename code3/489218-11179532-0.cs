    /// <summary>
    /// Represents a date between January 1, 0001 CE, and December 31, 9999 CE, in the proleptic Gregorian calendar.
    /// </summary>
    public struct Date
    {
        public const Int32 DaysPerYear = 365;
        public const Int32 MonthsPerYear = 12;
        private const UInt32 MaxSerialNumber = 3652058;
        private const UInt32 December = 11; // 0-based
        private const UInt32 DaysInDecember = 31;
        private const UInt32 LeapYearInterval1 = 4;
        private const UInt32 LeapYearInterval2 = 100;
        private const UInt32 LeapYearInterval3 = 400;
        private const UInt32 DaysPerLeapYearInterval1 =
            DaysPerYear * LeapYearInterval1 + 1; // +1 leap day every 4 years
        private const UInt32 DaysPerLeapYearInterval2 =
            DaysPerLeapYearInterval1 * (LeapYearInterval2 / LeapYearInterval1) - 1; // -1 leap day every 100 years
        private const UInt32 DaysPerLeapYearInterval3 =
            DaysPerLeapYearInterval2 * (LeapYearInterval3 / LeapYearInterval2) + 1; // +1 leap day every 400 years
        private static readonly UInt32[] DaysOfYear =
            new UInt32[(MonthsPerYear + 1) * 2]
            {
                0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334, 365,
                0, 31, 60, 91, 121, 152, 182, 213, 244, 274, 305, 335, 366,
            };
        private readonly UInt16 _zeroBasedYear; // 0 to 9998
        private readonly Byte _zeroBasedMonth; // 0 to 11
        private readonly Byte _zeroBasedDay; // 0 to 30
        /// <summary>
        /// Initializes a new instance of the <see cref="Date" /> structure to a specified serial number.
        /// </summary>
        /// <param name="serialNumber">
        /// The <see cref="SerialNumber" /> of the new <see cref="Date" />.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="serialNumber" /> is less than 0 or greater than 3652058.
        /// </exception>
        public Date(Int32 serialNumber)
        {
            Require.IsBetween("serialNumber", serialNumber, 0, (Int32)MaxSerialNumber);
            UInt32 days = (UInt32)serialNumber;
            // Find the first year of the 400-year period that contains the date:
            UInt32 zeroBasedYear = days / DaysPerLeapYearInterval3 * LeapYearInterval3;
            days %= DaysPerLeapYearInterval3;
            // Within the 400-year period, advance to the first year of the century that contains the date:
            UInt32 centuries = days / DaysPerLeapYearInterval2;
            zeroBasedYear += centuries * LeapYearInterval2;
            // Special case: If the date is the last day (December 31) of the 400-year period,
            // then "centuries" will be out of range because the fourth century has one more day than the others:
            if (centuries == LeapYearInterval3 / LeapYearInterval2)
                goto December31;
            days %= DaysPerLeapYearInterval2;
            // Within the century, advance to the first year of the 4-year period that contains the date:
            zeroBasedYear += days / DaysPerLeapYearInterval1 * LeapYearInterval1;
            days %= DaysPerLeapYearInterval1;
            // Within the 4-year period, advance to the year that contains the date:
            UInt32 years = days / DaysPerYear;
            zeroBasedYear += years;
            // Special case: If the date is the last day (December 31) of the 4-year period,
            // then "years" will be out of range because the fourth year has one more day than the others:
            if (years == LeapYearInterval1)
                goto December31;
            days %= DaysPerYear;
            // Estimate the month using an efficient divisor:
            Int32 index = GetDaysOfYearIndex(zeroBasedYear);
            UInt32 zeroBasedMonth = days / 32;
            // If the estimate was too low, adjust it:
            if (days >= DaysOfYear[index + (Int32)zeroBasedMonth + 1])
                ++zeroBasedMonth;
            _zeroBasedYear = (UInt16)zeroBasedYear;
            _zeroBasedMonth = (Byte)zeroBasedMonth;
            _zeroBasedDay = (Byte)(days - DaysOfYear[index + (Int32)zeroBasedMonth]);
            return;
        December31:
            _zeroBasedYear = (UInt16)(zeroBasedYear - 1);
            _zeroBasedMonth = (Byte)December;
            _zeroBasedDay = (Byte)(DaysInDecember - 1);
        }
        private static Int32 GetDaysOfYearIndex(UInt32 zeroBasedYear)
        {
            return !InternalIsLeapYear(zeroBasedYear) ? 0 : MonthsPerYear + 1;
        }
        private static Boolean InternalIsLeapYear(UInt32 zeroBasedYear)
        {
            UInt32 year = zeroBasedYear + 1;
            return
                (year % LeapYearInterval1 == 0) &&
                (year % LeapYearInterval2 != 0 || year % LeapYearInterval3 == 0);
        }
    }
