            static int? verifyParse(string str, string lable)
            {
                int? testedVar = TryParse(str);
                if (testedVar == null)
                {
                    Console.WriteLine("Este campo pode apenas conter dígitos de 0 à 9.");
                    Console.Write(lable);
                    int? newVal = verifyParse(Console.ReadLine(), lable);
                    if (newVal != null)
                        return newVal;
                    else
                        return null;
                }
                else
                {
                    return testedVar;
                }
            }//End of verifyParse();
