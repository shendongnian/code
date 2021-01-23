    [Route("/jtip/cases/{Count}, GET")]
    public class AgencyCaseSummary : IReturn<AgencyCaseSummaryResponse>
    {
        public int Count { get; set; }
    }
