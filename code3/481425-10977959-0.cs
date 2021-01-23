                var sqrtMax = (int)Math.Sqrt(maxNumber);
                var primeCandidates = Enumerable.Range(2, sqrtMax-1)
                 .ToDictionary(number => number, isComposite => false);
    
                foreach (var number in primeCandidates.Keys.ToArray())
                {
                    if (primeCandidates[number])
                    {
                        continue;
                    }
                    Parallel.ForEach(Enumerable.Range(2, sqrtMax / number - 1).Select(times => number * times),multiples=>
                        primeCandidates[multiples] = true);
                }
                var primeList = primeCandidates.Where(number => !number.Value).Select(pair=>pair.Key).ToArray();
                var maxPrime = maxNumber;
                
                    
                while (primeList.AsParallel().Any(prime=> maxPrime%prime==0))
                {
                    maxPrime--;
                }
