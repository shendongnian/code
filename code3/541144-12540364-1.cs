    String swissNumberStr = "044 668 18 00";
    PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
                try
                {
                    PhoneNumber swissNumberProto = phoneUtil.Parse(swissNumberStr, "CH");
                    Console.WriteLine(swissNumberProto.CountryCode);
                }
                catch (NumberParseException e)
                {
                    Console.WriteLine("NumberParseException was thrown: " + e.ToString());
                }
