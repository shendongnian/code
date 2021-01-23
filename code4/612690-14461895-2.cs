    public static IEnumerable<object[]> Numbers
        {
            get
            {
                List<object[]> testCases = new List<object[]>();
                testCases.AddRange(
                    from x in new[]
                    {1, 2, 3, 4, 5, 6, 7, 8}
                    select new object[] {x});
                return testCases;
            }
        }
        [TestCaseSource("Numbers")]
        public void CreateApplication(
            int number
            )
        {
             string company = DateTime.Now.ToString("dd/MM/yy ") + ("company") + number.ToString();
        }
