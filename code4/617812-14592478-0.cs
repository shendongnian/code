            char[] upperChars = Enumerable.Range(65, 26).Select(c => (Char)c).ToArray();
            char[] lowerChars = Enumerable.Range(97, 26).Select(c => (Char)c).ToArray();
            char[] allChars =
                (Enumerable.Range(65, 26).Select(c => (Char) c)
                .Union(Enumerable.Range(97, 26).Select(c => (Char) c)))
                .ToArray();
