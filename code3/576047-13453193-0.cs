    private static IEnumerable FileIterator(String filePathe)
        {
            using (StreamReader streamReader = new StreamReader(filePathe))
            {
                String line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    yield return line;
                }
                yield break;
            }
        }
