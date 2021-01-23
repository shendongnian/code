                try
                {
                    // Print the Xps file while providing XPS validation and progress notifications.
                    PrintSystemJobInfo xpsPrintJob = defaultPrintQueue.AddJob(f.Name, nextFile, false);
                }
                catch (PrintJobException e)
                {
                    Console.WriteLine("\n\t{0} could not be added to the print queue.", f.Name);
                    if (e.InnerException.Message == "File contains corrupted data.")
                    {
                        Console.WriteLine("\tIt is not a valid XPS file. Use the isXPS Conformance Tool to debug it.");
                    }
                    Console.WriteLine("\tContinuing with next XPS file.\n");
                }
