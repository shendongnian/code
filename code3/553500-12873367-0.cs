    richTextBox2.AppendText(string.Join("\n",
                                          Enumerable.Range(0, numberOfCodons)
                                            .Select(i => RNA.Substring(i * 3, i * 3 + 3))
                                            .Where(c => codons.Contains(c))
                                            .Select(c => codons.IndexOf(c))
                                            .Select(ci => aminoAcids[ci])
                                            .ToArray())
                                        );
