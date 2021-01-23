    richTextBox2.AppendText(string.Join("\n",
                                          Enumerable.Range(0, numberOfCodons)
                                            .Select(i => RNA.Substring(i * 3, i * 3 + 3))
                                            .Where(c => codons.Contains(c))
                                            .Select(c => aminoAcids[codons.IndexOf(c)])
                                            .ToArray())
                                        );
