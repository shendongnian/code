            IEnumerable<Glyph> requirements = t.Objectives.Cast<Glyph>().OrderBy(k => k.Name);
            IEnumerable<Glyph> candidates = Resources.Cast<Glyph>().OrderBy(k => k.Name);
            IEnumerable<Glyph> zeroCountCandidates = candidates.Where(c => c.Count == 0);
            IEnumerable<Glyph> zeroCountRequirements = requirements.Where(r => r.Count == 0);
            List<Glyph> remainingCandidates = zeroCountCandidates.ToList();
            if (zeroCountCandidates.Count() < zeroCountRequirements.Count())
            {
                return false;
            }
            foreach (var r in zeroCountRequirements)
            {
                if (!remainingCandidates.Contains(r))
                {
                    return false;
                }
                else
                {
                    remainingCandidates.Remove(r);
                }
            }
            IEnumerable<Glyph> nonZeroCountCandidates = candidates.Where(c => c.Count > 0);
            IEnumerable<Glyph> nonZeroCountRequirements = requirements.Where(r => r.Count > 0);
            var perms = nonZeroCountCandidates.Permutations();
            foreach (var perm in perms)
            {
                bool isViableSolution = true;
                remainingCandidates = perm.ToList();
                foreach (var requirement in nonZeroCountRequirements)
                {
                    int countThreshold = requirement.Count;
                    while (countThreshold > 0)
                    {
                        if (remainingCandidates.Count() == 0)
                        {
                            isViableSolution = false;
                            break;
                        }
                        var c = remainingCandidates[0];
                        countThreshold -= c.Count;
                        remainingCandidates.Remove(c);
                    }
                }
                if (isViableSolution)
                {
                    return true;
                }
            }
            return false;
