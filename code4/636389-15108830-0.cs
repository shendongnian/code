     try
            {
                // Get the type of a specified class.
                Type myType1 = Type.GetType("System.Int32");
                Console.WriteLine("The full name is {0}.", myType1.FullName);
                // Since NoneSuch does not exist in this assembly, GetType throws a TypeLoadException.
                Type myType2 = Type.GetType("NoneSuch", true);
                Console.WriteLine("The full name is {0}.", myType2.FullName);
            }
            catch(TypeLoadException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
