        private IEnumerable<string> BreakString(string source)
        {
            var delimiter = '/';
            var head = source.TakeWhile(c => c != delimiter);
            if (!head.Any())
            {
                yield break;
            }
            var tail = source.SkipWhile(c => c != delimiter)
                .Skip(1);
            yield return String.Join("", head);
            foreach (var t in BreakString(String.Join("", tail)))
            {
                yield return t;
            }
        }
    // usage
    from s in BreakString(source)
