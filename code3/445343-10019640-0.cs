        static IEnumerable<List<byte>> AscPerm(List<byte> inBytes, int combinations)
        {
            if (combinations == 1)
            {
                foreach (var b in inBytes)
                {
                    yield return new List<byte> { b };
                }
            }
            else
            {
                for (int i = 0; i <= inBytes.Count - combinations; i++)
                {
                    // Recurse down, passing in all but first item of inBytes.
                    var subPerms = AscPerm(inBytes.Skip(1).ToList(), combinations - 1);
                    foreach (var subPerm in subPerms)
                    {
                        List<byte> retBytes = new List<byte>{ inBytes[i] };
                        yield return retBytes.Concat(subPerm).ToList();
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            var retList = AscPerm(new List<byte> { 1, 2, 3, 4, 5, 6, 7 }, 3);
            foreach (var ret in retList)
            {
                foreach (var r in ret)
                {
                    Console.Write(r);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
