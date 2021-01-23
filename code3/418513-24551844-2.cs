    public sealed class TestMutliHeadService : ITestMutliHeadService, ITestMutliHeadServiceSchemaCompliant
    {
        public ResponseDocument LoadChildren(IncomingDocument request)
        {
            int count = 0;
            if (request.ChildrensNames != null)
            {
                count = request.ChildrensNames.Count();
            }
            return new ResponseDocument()
            {
                NumberOfChildren = count,
            };
        }
        public DayDetails DayDetails()
        {
            return new DayDetails()
            {
                CurrentDateTime = DateTime.Now,
                WeatherDetails = "It's rather nice, really.",
            };
        }
        public string Test(string input)
        {
            return input;
        }
    }
