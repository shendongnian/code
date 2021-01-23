                    else if (pdfFields is PDRadioCollection)
                    {
                        System.Console.WriteLine("Radio Button" + "   "
                                + pdfFields.getFullyQualifiedName() + "  ");
                        System.Collections.IEnumerable kids = (System.Collections.IEnumerable)pdfFields.getKids();
                        System.Console.WriteLine(kids);
                        foreach (var kid in kids)
                        {
                            PDCheckbox checkbox = (PDCheckbox)kid;
                            string Name = checkbox.getOnValue();
                            System.Console.WriteLine(Name);
                        }
