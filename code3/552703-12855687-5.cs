     private static void EnumerateAssembly(AssemblyDefinition assembly)
            {
                foreach (var module in assembly.Modules)
                {
                    foreach (var type in module.GetAllTypes())
                    {
                        foreach (var field in type.Fields)
                        {
                            Debug.Print(field.ToString());
                        }
                        foreach (var method in type.Methods)
                        {
                            Debug.Print(method.ToString());
                            foreach (var instruction in method.Body.Instructions)
                            {
                                Debug.Print(instruction.ToString());
                            }
                        }
                    }
                }
            }
