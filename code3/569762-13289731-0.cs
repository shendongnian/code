    using System;
    using System.Collections.Generic;
    
    namespace MatchCondition
    {
        class MatchCondition
        {
            private enum TaxProfileEnum
            {
                Default = 0,
                America1 = 100,
                America2 = 200,
                India1 = 300,
                India2 = 400,
            }
    
            private enum CurrencyEnum
            {
                Rupee = 100,
                Dollar = 200,
            }
    
            static void Main(string[] args)
            {
                try
                {
                    Dictionary<CurrencyEnum, List<TaxProfileEnum>> validCurrencies = new Dictionary<CurrencyEnum, List<TaxProfileEnum>>()
                    {
                        { CurrencyEnum.Rupee, new List<TaxProfileEnum>()  { TaxProfileEnum.India1, TaxProfileEnum.India2 } },
                        { CurrencyEnum.Dollar, new List<TaxProfileEnum>() { TaxProfileEnum.America1, TaxProfileEnum.America2 } },
                    };
    
                    CurrencyEnum currency = (CurrencyEnum)int.Parse(args[0]);
                    TaxProfileEnum taxProfile = (TaxProfileEnum)int.Parse(args[1]);
    
                    if (taxProfile == TaxProfileEnum.Default)
                    {
                        Console.WriteLine("All is well!");
                        return;
                    }
    
                    List<TaxProfileEnum> validTaxes;
                    if (validCurrencies.TryGetValue(currency, out validTaxes) && validTaxes.Contains(taxProfile))
                    {
                        Console.WriteLine("All is well!");
                        return;
                    }
    
                    Console.WriteLine("Mismatch Detected!");
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }
