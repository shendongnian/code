        public static void TestSpeed()
        {
            var testData = "fooooo-bar";
            var timer = new Stopwatch();
            timer.Start();
            for (var i = 0; i < 10000; i++)
                Assert.AreEqual("bar", GetNameCompiled(testData));
            timer.Stop();
            Console.WriteLine("Compiled took " + timer.ElapsedMilliseconds + "ms");
            timer.Reset();
            timer.Start();
            for (var i = 0; i < 10000; i++)
                Assert.AreEqual("bar", GetName(testData));
            timer.Stop();
            Console.WriteLine("Uncompiled took " + timer.ElapsedMilliseconds + "ms");
            timer.Reset();
        }
        private static readonly Regex CompiledRegex = new Regex("^[a-zA-Z]+-", RegexOptions.Compiled);
        private static string GetNameCompiled(string objString)
        {
            return CompiledRegex.Replace(objString, "");
        }
        private static string GetName(string objString)
        {
            return Regex.Replace(objString, "^[a-zA-Z]+-", "");
        }
