    public ActionResult Index() {
        var hs as headerWithSum;
        List<HeaderWithSum> headerWithSum;
        List<Header> headers = headerRepository.GetAll();
        int sum = 0;
        foreach(var h in headers) {
            sum = h.GetSumOfDetails();
            hs = new HeaderWithSum()
                 {
                     Header = h , Sum = sum
                 };
            headerWithSum.Add(hs);
        }
        return View(headerWithSum);
    }
