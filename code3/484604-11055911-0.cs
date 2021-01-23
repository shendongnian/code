            private static int[]
                C93Table = { 131112, 111213, 111312, 111411, 121113, 121212, 121311, 111114, 131211, 141111, 211113, 211212, 211311, 221112, 221211, 231111, 112113, 112212, 112311, 122112, 132111, 111123, 111222, 111321, 121122, 131121, 212112, 212211, 211122, 211221, 221121, 222111, 112122, 112221, 122121, 123111, 121131, 311112, 311211, 321111, 112131, 113121, 211131, 121221, 312111, 311121, 122211 };
            static string[]
                C93TableX = { "bU", "aA", "aB", "aC", "aD", "aE", "aF", "aG", "aH", "aI", "aJ", "aK", "aL", "aM", "aN", "aO", "aP", "aQ", "aR", "aS", "aT", "aU", "aV", "aW", "aX", "aY", "aZ", "bA", "bB", "bC", "bD", "bE", " ", "cA", "cB", "cC", "cD", "cE", "cF", "cG", "cH", "cI", "cJ", "cK", "cL", "cM", "cN", "cO", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "cZ", "bF", "bG", "bH", "bI", "bJ", "bV", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "bK", "bL", "bM", "bN", "bO", "bW", "dA", "dB", "dC", "dD", "dE", "dF", "dG", "dH", "dI", "dJ", "dK", "dL", "dM", "dN", "dO", "dP", "dQ", "dR", "dS", "dT", "dU", "dV", "dW", "dX", "dY", "dZ", "bP", "bQ", "bR", "bS", "bT" };
            static string C93Set = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%abcd";
    
    private void Code93X()
            {
                string source = request.Data;
                Error valid = Validate(source, 197, C93Set);
                if (valid != Error.None)
                {
                    encoded = new Encoded() { Error = valid };
                    return;
                }
                StringBuilder adapt = new StringBuilder();
                for (int i = 0; i < source.Length; i++)
                    adapt.Append(C93TableX[(byte)source[i]]);
                Code93(adapt.ToString());
            }
    
    private void Code93(string source)
            {
                StringBuilder bars = new StringBuilder();
                bars.Append(111141);
                int c = 0, k = 0;
                int[] values = new int[source.Length + 1];
                for (int i = 0; i < source.Length; i++)
                {
                    values[i] = C93Set.IndexOf(source[i]);
                    bars.Append(C93Table[values[i]]);
                }
                if (request.AddChecksum)
                {
                    int weight = 1;
                    for (int i = source.Length - 1; i >= 0; i--)
                    {
                        c += values[i] * weight;
                        if (++weight == 21)
                            weight = 1;
                    }
                    c %= 47;
                    values[source.Length] = c;
                    bars.Append(C93Table[c]);
                    source += C93Set[c];
                    weight = 1;
                    for (int i = source.Length - 1; i >= 0; i--)
                    {
                        k += values[i] + weight;
                        if (++weight == 16)
                            weight = 1;
                    }
                    k %= 47;
                    bars.Append(C93Table[k]);
                    if (request.DisplayChecksum)
                        source += C93Set[k];
                }
                bars.Append(1111411);
                source = string.Concat("*", source, "*");
                encoded = new Encoded(bars.ToString(), source);
            }
    
    
            private Error Validate(string source, int maxLength, string set)
            {
                Error valid = Validate(source, maxLength);
                if (valid == Error.None)
                    for (var i = 0; i < source.Length; i++)
                        if (set.IndexOf(source[i]) < 0)
                        {
                            valid = Error.InvalidCharacters;
                            break;
                        }
                return valid;
            }
