    using System;
    using System.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            class VatNumber
            {
                private int[] _numericVatNumber;
                public int[] NumericVatNumber { get { return _numericVatNumber; } }
                public VatNumber(string vatNumber)
                {
                    _numericVatNumber = vatNumber.ToCharArray().Select(i => int.Parse(i.ToString())).ToArray();
                }
                public virtual bool IsValid(){return false;}
            }
            class PersonalVatNumber : VatNumber
            {
                public override bool IsValid()
                {
                    var n10 = ((2 * NumericVatNumber[0] +
                                4 * NumericVatNumber[1] +
                                10 * NumericVatNumber[2] +
                                3 * NumericVatNumber[3] +
                                5 * NumericVatNumber[4] +
                                9 * NumericVatNumber[5] +
                                4 * NumericVatNumber[6] +
                                6 * NumericVatNumber[7] +
                                8 * NumericVatNumber[8]) % 11) % 10;
                    if (n10 == NumericVatNumber.Last())
                        return true;
                    return false;
                }
                public PersonalVatNumber(string vatNumber)
                    : base(vatNumber)
                {
                }
            }
            class CompanyVatNumber : VatNumber
            {
                public override bool IsValid()
                {
                    var n11 = ((7 * NumericVatNumber[0] +
                                2 * NumericVatNumber[1] +
                                4 * NumericVatNumber[2] +
                                10 * NumericVatNumber[3] +
                                3 * NumericVatNumber[4] +
                                5 * NumericVatNumber[5] +
                                9 * NumericVatNumber[6] +
                                4 * NumericVatNumber[7] +
                                6 * NumericVatNumber[8] +
                                8 * NumericVatNumber[9]
                                ) % 11) % 10;
                                    if (n11 != NumericVatNumber[10])
                        return false;
                    var n12 = ((3 * NumericVatNumber[0] +
                                7 * NumericVatNumber[1] +
                                2 * NumericVatNumber[2] +
                                4 * NumericVatNumber[3] +
                                10 * NumericVatNumber[4] +
                                3 * NumericVatNumber[5] +
                                5 * NumericVatNumber[6] +
                                9 * NumericVatNumber[7] +
                                4 * NumericVatNumber[8] +
                                6 * NumericVatNumber[9] +
                                8 * NumericVatNumber[10]
                                ) % 11) % 10;
                    if (n12 == NumericVatNumber.Last())
                        return true;
                    return false;
                }
                public CompanyVatNumber(string vatNumber)
                    : base(vatNumber)
                {
                }
            }
            static void Main(string[] args)
            {
                var companyVat = new CompanyVatNumber("123456789047");
                Console.WriteLine(companyVat.IsValid());
                var personalVat = new PersonalVatNumber("1234567894");
                Console.WriteLine(personalVat.IsValid());
            }
        }
    }
