            public static string GetRandomString(int randomStrLength)
            {
                Random rand = new Random(DateTime.Now.Millisecond);
                char[] randomString = new char[randomStrLength];
                int randCode = 0;
                bool containsDigit = false;
                while (containsDigit == false)
                {
                    for (int i = 0; i < randomStrLength; i++)
                    {
                        // Get random asci codes (allowed: a-z, A-Z, 0-9)
                        do
                        {
                            randCode = rand.Next(48, 122);
                        }
                        while (randCode > 57 && randCode < 65 || randCode > 90 && randCode < 97);
                        randomString[i] = (char)randCode;
                        // We want at least one digit.
                        if (randCode >= 48 && randCode <= 57)
                        {
                            containsDigit = true;
                        }
                    }
                }
                return new String(randomString);
            }
