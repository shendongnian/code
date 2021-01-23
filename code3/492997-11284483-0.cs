        static void Main(string[] args)
        {
             const string xml = @"<SomeRootTag>
                <Msg UserText='start 0'>
                </Msg>
                <Msg UserText='A'>
                </Msg>
                <Msg UserText='A'>
                </Msg>
                <Msg UserText='start 1'>
                </Msg>
                <Msg UserText='A'>
                </Msg>
                <Msg UserText='start 2'>
                </Msg>
                <Msg UserText='A'>
                </Msg>
                <Msg UserText='A'>
                </Msg>
                <Msg UserText='A'>
                </Msg>
            </SomeRootTag>";
            var xDoc = XDocument.Load(new StringReader(xml));
            var msgs = xDoc.Root.Elements().Where(el => el.Name == "Msg").Select(el => el.Attribute("UserText").Value);
            var results = GetCounts(msgs);
           
            foreach (var keyValue in results)
            {
                Console.WriteLine("{0}:{1}", keyValue.Item1, keyValue.Item2);
            }
            Console.ReadKey();
        }
        private static IEnumerable<Tuple<string,int>> GetCounts(IEnumerable<string> msgs)
        {
            string last = null;
            int count = 0;
            foreach (var msg in msgs)
            {
                if (msg.StartsWith("start"))
                {
                    if (last != null)
                    {
                        yield return new Tuple<string, int>(last, count);
                    }
                    count = 0;
                    last = msg;
                }
                else
                {
                    count++;
                }
            }
            yield return new Tuple<string, int>(last, count);
        }  
