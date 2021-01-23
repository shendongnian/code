    [Test]
    public void ABCC_0063__with_candidates__BCADCC_010244__should_return_false()
    {
        var requirementNames = "ABCC".Select(x => x.ToString()).ToArray();
        var requirementCounts = new[] {0, 0, 6, 3};
        var candidateNames = "BCADCC".Select(x => x.ToString()).ToArray();
        var candidateCounts = new[] {0, 1, 0, 2, 4, 4};
        var actual = IsValid(requirementNames, requirementCounts, candidateNames, candidateCounts);
        actual.ShouldBeFalse();
    }
    [Test]
    public void ABC_003__with_candidates__BCADCC_010244__should_return_true()
    {
        var requirementNames = "ABC".Select(x => x.ToString()).ToArray();
        var requirementCounts = new[] {0, 0, 3};
        var candidateNames = "BCADCC".Select(x => x.ToString()).ToArray();
        var candidateCounts = new[] {0, 1, 0, 2, 4, 4};
        var actual = IsValid(requirementNames, requirementCounts, candidateNames, candidateCounts);
        actual.ShouldBeTrue();
    }
    [Test]
    public void ABC_003__with_candidates__BCAD_0102__should_return_false()
    {
        var requirementNames = "ABC".Select(x => x.ToString()).ToArray();
        var requirementCounts = new[] {0, 0, 3};
        var candidateNames = "BCAD".Select(x => x.ToString()).ToArray();
        var candidateCounts = new[] {0, 1, 0, 2};
        var actual = IsValid(requirementNames, requirementCounts, candidateNames, candidateCounts);
        actual.ShouldBeFalse();
    }
    [Test]
    public void ABC_009__with_candidates__BCADCC_010244__should_return_true()
    {
        var requirementNames = "ABC".Select(x => x.ToString()).ToArray();
        var requirementCounts = new[] {0, 0, 9};
        var candidateNames = "BCADCC".Select(x => x.ToString()).ToArray();
        var candidateCounts = new[] {0, 1, 0, 2, 4, 4};
        var actual = IsValid(requirementNames, requirementCounts, candidateNames, candidateCounts);
        actual.ShouldBeTrue();
    }
    
    [Test]
    public void FuzzTestIt()
    {
        var random = new Random();
        const string names = "ABCDE";
        for (var tries = 0; tries < 10000000; tries++)
        {
            var numberOfRequirements = random.Next(5);
            var shouldPass = true;
            var requirementNames = new List<string>();
            var requirementCounts = new List<int>();
            var candidateNames = new List<string>();
            var candidateCounts = new List<int>();
            for (var i = 0; i < numberOfRequirements; i++)
            {
                var name = names.Substring(random.Next(names.Length), 1);
                switch (random.Next(6))
                {
                    case 0: // zero-requirement with corresponding candidate
                        requirementNames.Add(name);
                        requirementCounts.Add(0);
                        candidateNames.Add(name);
                        candidateCounts.Add(0);
                        break;
                    case 1: // zero-requirement without corresponding candidate
                        requirementNames.Add(name);
                        requirementCounts.Add(0);
                        shouldPass = false;
                        break;
                    case 2: // non-zero-requirement with corresponding candidate
                        {
                            var count = random.Next(1, 10);
                            requirementNames.Add(name);
                            requirementCounts.Add(count);
                            candidateNames.Add(name);
                            candidateCounts.Add(count);
                        }
                        break;
                    case 3: // non-zero-requirement with matching sum of candidates
                        {
                            var count = random.Next(1, 10);
                            requirementNames.Add(name);
                            requirementCounts.Add(count);
                            foreach (var value in GetAddendsFor(count, random))
                            {
                                candidateNames.Add(name);
                                candidateCounts.Add(value);
                            }
                        }
                        break;
                    case 4: // non-zero-requirement with matching overflow candidate
                        {
                            var count = random.Next(1, 10);
                            requirementNames.Add(name);
                            requirementCounts.Add(count);
                            candidateNames.Add(name);
                            candidateCounts.Add(count + 2);
                        }
                        break;
                    case 5: // non-zero-requirement without matching candidate or sum or candidates
                        {
                            var count = random.Next(10, 20);
                            requirementNames.Add(name);
                            requirementCounts.Add(count);
                            shouldPass = false;
                        }
                        break;
                }
            }
            try
            {
                var actual = IsValid(requirementNames, requirementCounts, candidateNames, candidateCounts);
                actual.ShouldBeEqualTo(shouldPass);
            }
            catch (Exception e)
            {
                Console.WriteLine("Requirements: " + String.Join(", ", requirementNames.ToArray()));
                Console.WriteLine("              " +
                                  String.Join(", ", requirementCounts.Select(x => x.ToString()).ToArray()));
                Console.WriteLine("Candidates:   " + String.Join(", ", candidateNames.ToArray()));
                Console.WriteLine("              " +
                                  String.Join(", ", candidateCounts.Select(x => x.ToString()).ToArray()));
                Console.WriteLine(e);
                Assert.Fail();
            }
        }
    }
